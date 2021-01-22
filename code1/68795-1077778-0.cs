        private Guid? id;
        private string text;
        public Guid?Id
        {
            get { return id; }
            set { 
                id = value;
                TrySetValue();
            }
        }
        public string Text 
        { 
            get { return text; }
            set { text = value;
            TrySetValue()} 
        }
        private void TrySetValue()
        {
            if (id != null && text != null)
            {
                SetValue(IdProperty, id);
                SetValue(TextProperty, text);
            }
        }
