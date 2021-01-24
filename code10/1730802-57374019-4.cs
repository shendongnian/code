     public static class ExtensionMethods
    {
        public static IDictionary<string, string> ToKeyValue(this object metaToken)
        {
            if (metaToken == null)
            {
                return null;
            }
            // Added by me: avoid cyclic references
            var serializer = new JsonSerializer { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var token = metaToken as JToken;
            if (token == null)
            {
                // Modified by me: use serializer defined above
                return ToKeyValue(JObject.FromObject(metaToken, serializer));
            }
            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = child.ToKeyValue();
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent)
                                                 .ToDictionary(k => k.Key, v => v.Value);
                    }
                }
                return contentData;
            }
            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }
            var value = jValue?.Type == JTokenType.Date ?
                            jValue?.ToString("o", CultureInfo.InvariantCulture) :
                            jValue?.ToString(CultureInfo.InvariantCulture);
            return new Dictionary<string, string> { { token.Path, value } };
        }
        public static FormUrlEncodedContent ToFormData(this object obj)
        {
            var formData = obj.ToKeyValue();
            return new FormUrlEncodedContent(formData);
        }
    }
