    class HelpTextEventArgs : EventArgs
    {
        public string Text { get; set; }
        public string FieldId { get; private set; }
        public HelpTextEventArgs(string fieldId)
        {
            FieldId = fieldId;
        }
    }
