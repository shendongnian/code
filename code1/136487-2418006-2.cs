    class Language
    {
        string text;
        string value;
        public string Text
        {
            get 
            {
                return text;
            }
        }
        public string Value
        {
            get
            {
                return value;
            }
        }
        public Language(string text, string value)
        {
            this.text = text;
            this.value = value;
        }
    }
    ...
    combo.DisplayMember= "Text";
    combo.ValueMember = "Value";
    combo.Items.Add(new Language("English", "en"));
