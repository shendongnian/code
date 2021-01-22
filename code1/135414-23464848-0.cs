    public class PushNotificationHelper
    {
        private readonly ILog log4netEngine;
    
        private string UrbanAirshipApplicationKey { get; set; }
        private string UrbanAirshipApplicationSecret { get; set; }
        private string UrbanAirshipApplicationMasterSecret { get; set; }
    
        public PushNotificationHelper(string UrbanAirshipApplicationKey, string UrbanAirshipApplicationSecret, string UrbanAirshipApplicationMasterSecret)
        {
            log4netEngine = LogManager.GetLogger(typeof(PushNotificationHelper).Name);
    
            this.UrbanAirshipApplicationKey = UrbanAirshipApplicationKey;
            this.UrbanAirshipApplicationSecret = UrbanAirshipApplicationSecret;
            this.UrbanAirshipApplicationMasterSecret = UrbanAirshipApplicationMasterSecret;
        }
    
    
        public void PushNotification2iPhones(string alertText, string[] apids, string extra)
        {
            if (!string.IsNullOrEmpty(alertText) && apids.Length > 0)
            {
                iPhonePushNotification pushNotification = new iPhonePushNotification
                {
                    MessageBody = new iPhonePushNotificationMessageBody
                    {
                        Alert = alertText
                    },
                    Extra = extra,
                    APIDs = apids
                };
                string jsonMessageRequest = pushNotification.ToJsonString();
                try
                {
                    SendMessageToUrbanAirship(jsonMessageRequest);
                    log4netEngine.InfoFormat("Push Notification Success , iPhoneDevice:{0}, message:{1},extra:{2}", string.Join(",", apids), alertText, extra);
                }
                catch (Exception ex)
                {
                    log4netEngine.InfoFormat("Push Notification Error:{0}, iPhoneDevice:{1}, message:{2},extra:{3}", ex.Message, string.Join(",", apids), alertText, extra);
                }
            }
        }
    
    
        public void PushNotification2Androids(string alertText, string[] apids, string extra)
        {
            if (!string.IsNullOrEmpty(alertText) && apids.Length > 0)
            {
                AndroidPushNotification pushNotification = new AndroidPushNotification
                {
                    MessageBody = new AndroidPushNotificationMessageBody
                    {
                        Alert = alertText,
                        Extra = extra
                    },
                    APIDs = apids
                };
                string jsonMessageRequest = pushNotification.ToJsonString();
    
                try
                {
                    SendMessageToUrbanAirship(jsonMessageRequest);
                    log4netEngine.InfoFormat("Push Notification Success , androidDevice:{0}, message:{1},extra:{2}", string.Join(",", apids), alertText, extra);
                }
                catch (Exception ex)
                {
                    log4netEngine.InfoFormat("Push Notification Error:{0}, androidDevice:{1}, message:{2},extra:{3}", ex.Message, string.Join(",", apids), alertText, extra);
                }
            }
        }
    
        private void SendMessageToUrbanAirship(string jsonMessageRequest)
        {
            var uri = new Uri("https://go.urbanairship.com/api/push/");
            var encoding = new UTF8Encoding();
            var request = WebRequest.Create(uri);
            request.Method = "POST";
            request.Credentials = new NetworkCredential(this.UrbanAirshipApplicationKey, this.UrbanAirshipApplicationMasterSecret);
            request.ContentType = "application/json";
            request.ContentLength = encoding.GetByteCount(jsonMessageRequest);
            using (var stream = request.GetRequestStream())
            {
                stream.Write(encoding.GetBytes(jsonMessageRequest), 0, encoding.GetByteCount(jsonMessageRequest));
                stream.Close();
                var response = request.GetResponse();
                response.Close();
            }
        }
    }
    
    public class NotificationToPush
    {
        public int ReceiverUserID { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Extra { get; set; }
    }
    
    [DataContract(Name = "PushNotificationBody")]
    internal class PushNotification
    {
        public string ToJsonString()
        {
            var result = JsonConvert.SerializeObject(this);
            return result;
        }
    }
    
    [DataContract(Name = "iPhonePushNotification")]
    internal class iPhonePushNotification : PushNotification
    {
        [DataMember(Name = "aps")]
        public iPhonePushNotificationMessageBody MessageBody { get; set; }
    
        [DataMember(Name = "extra")]
        public string Extra { get; set; }
    
        [DataMember(Name = "device_tokens")]
        public string[] APIDs { get; set; }
    }
    
    [DataContract(Name = "iPhonePushNotificationMessageBody")]
    internal class iPhonePushNotificationMessageBody
    {
        [DataMember(Name = "alert")]
        public string Alert { get; set; }
    }
    
    [DataContract(Name = "AndroidPushNotification")]
    internal class AndroidPushNotification : PushNotification
    {
        [DataMember(Name = "android")]
        public AndroidPushNotificationMessageBody MessageBody { get; set; }
    
        [DataMember(Name = "apids")]
        public string[] APIDs { get; set; }
    }
    
    [DataContract(Name = "AndroidPushNotificationMessageBody")]
    internal class AndroidPushNotificationMessageBody
    {
        [DataMember(Name = "alert")]
        public string Alert { get; set; }
    
        [DataMember(Name = "extra")]
        public string Extra { get; set; }
    }
