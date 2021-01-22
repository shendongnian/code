        [DataContract]
        public class CustomFault
        {
           public CustomFault()
           {
           }
            public CustomFault(string message)
            {
                Message = message;
            }
            [DataMember]
            public string Message { get; private set; }
        }
