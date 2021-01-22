    public class CACDocument : ITextDocument {
        // ...
        [XmlIgnore]
        public string Text {get;set;}
    
        [XmlText]
        public byte[] TextSubstitute {
            get {return System.Text.Encoding.UTF8.GetBytes(Text);}
            set {Text = System.Text.Encoding.UTF8.GetString(value);}
        }
    }
