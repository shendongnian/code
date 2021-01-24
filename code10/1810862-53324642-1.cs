        public IEnumerable<string> Messages { get; set; }
        public string AllMessages => GetAllMessages();
        private string GetAllMessages()
        {
            var builder = new StringBuilder();
            foreach (var message in Messages)
            {
               //Add in whatever for context
               builder.AppendLine(message);
            }
            return builder.ToString();
        }       
