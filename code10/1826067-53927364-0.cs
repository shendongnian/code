      class Content{
        public dynamic MessageBody { get; set; }
        public dynamic MessageHeader { get; set; }
      }
      var message = JsonConvert.DeserializeObject<Content>(msg);
      var messageContext = message.MessageHeader;
