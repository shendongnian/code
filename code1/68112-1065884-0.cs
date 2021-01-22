    [DataContract]
    public class Something
    {
        [DataMember]
        public string Text {get; private set;}
    
        private Something()
        {
            Text = string.Empty;
        }
    
        public Something(string text)
        {
            Text = text;
        }
    }
