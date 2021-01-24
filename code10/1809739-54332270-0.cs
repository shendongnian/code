Google.Apis.Requests.RequestError
Invalid JSON payload received. Unknown name "ETag" at 'dynamic_link_info.android_info': Cannot find field.
Invalid JSON payload received. Unknown name "ETag" at 'dynamic_link_info.ios_info': Cannot find field.
Invalid JSON payload received. Unknown name "ETag" at 'dynamic_link_info': Cannot find field.
Invalid JSON payload received. Unknown name "ETag" at 'suffix': Cannot find field.
Invalid JSON payload received. Unknown name "ETag": Cannot find field. [400]
I haven't found a way around ManagedShortLinks.  However, `ShortLinks` will work.  I'll show you how I did it.
 c#
        public async Task<string> GetDeepLink(Invitation inv)
        {
            var playId = _configurationProvider.GetSetting(AppSettingNames.GooglePlayAppId);
            var iosId = _configurationProvider.GetSetting(AppSettingNames.AppleAppStoreAppId);
            var domain = _configurationProvider.GetSetting(AppSettingNames.GoogleFirebaseDynamicLinkDomain);
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["Key1"] = "value1";
            var mslReq = new CreateShortDynamicLinkRequest();
            mslReq.DynamicLinkInfo = new DynamicLinkInfo();
            mslReq.DynamicLinkInfo.AndroidInfo = new AndroidInfo() { AndroidPackageName = playId };
            mslReq.DynamicLinkInfo.IosInfo = new IosInfo() { IosAppStoreId = iosId, IosBundleId = playId };
            mslReq.DynamicLinkInfo.DomainUriPrefix = $"https://{domain}";
            mslReq.DynamicLinkInfo.Link = $"https://www.example.com/?{queryString}";
            mslReq.Suffix = new Suffix() { Option = "SHORT" };
            var json = JsonConvert.SerializeObject(mslReq, Formatting.Indented, new CreateShortDynamicLinkRequestConverter());
            var request = _firebaseDynamicLinksService.ShortLinks.Create(new CreateShortDynamicLinkRequest());
            
            request.ModifyRequest = message =>
                message.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await request.ExecuteAsync();
            return res.ShortLink;
        }
This depends upon `CreateShortDynamicLinkRequestConverter`:
    public class CreateShortDynamicLinkRequestConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.NullValueHandling = NullValueHandling.Ignore;
            var t = JToken.FromObject(value);
            var modified = t.RemoveFields("ETag");
            modified.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override bool CanRead => false;
    }
which in turn depends upon `RemoveFields`: 
        // source: https://stackoverflow.com/a/31581951/773673
        public static JToken RemoveFields(this JToken token, params string[] fields)
        {
            JContainer container = token as JContainer;
            if (container == null) return token;
            List<JToken> removeList = new List<JToken>();
            foreach (JToken el in container.Children())
            {
                JProperty p = el as JProperty;
                if (p != null && (fields.Contains(p.Name)))
                {
                    removeList.Add(el);
                }
                el.RemoveFields(fields);
            }
            foreach (JToken el in removeList)
            {
                el.Remove();
            }
            return token;
        }
At the end of the day, the big problem here is the lack of decoration of the `ETag` members.  We need to work around that.  I believe that customizing `BaseClientService.Initializer.Serializer` when the service is instantiated with the `public NewtonsoftJsonSerializer(JsonSerializerSettings settings)` constructor will allow you to specify the `Converters` to use, but I stopped when I got it working.  The real fix for this is to simply decorate the ETag members to not participate in serialization (providing that doesn't break anything else!).
