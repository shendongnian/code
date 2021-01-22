    public partial class CustomControl: UserControl
    {
        public string Extension { get; set; }
        private string _text;
        [BrowsableAttribute(true)] // Initializes to "customControlN"
        public override string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
