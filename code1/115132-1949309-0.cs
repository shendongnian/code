        public FieldFormatException(Fields field, string value): 
            base(BuildMessage(field, value))
        {
        }
        private static string BuildMessage(Fields field, string value)
        {
           // return the message you want
        }
 
