        public string[] HandleMessage<MessageType>(MessageType input) {
           var parser = StructureMap.GetInstance<IParser<MessageType>>();
           parser.SetInput(input);
           var command = parser.GetCommand();
           //do something about the rest
       }
