     public class RetryEnabledErrorMessageSerializer<T> : IErrorMessageSerializer where T : class, IMessageType
     {
            public string Serialize(byte[] messageBody)
            {
                 string stringifiedMsgBody = Encoding.UTF8.GetString(messageBody);
                 var objectifiedMsgBody = JObject.Parse(stringifiedMsgBody);
    
                 // Add/update RetryInformation into objectifiedMsgBody here
                 // I have a dictionary that saves <key:consumerId, val: TryInfoObj>
    
                 return JsonConvert.SerializeObject(objectifiedMsgBody);
            }
      }
