    public class Device : IEditableObject
    {
        private string _originalValue;
        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string OriginalValue => _originalValue;
        public void BeginEdit()
        {
            //store the original value(s)
            _originalValue = _value;
        }
        public void CancelEdit() { }
        public void EndEdit() { }
        public void Commit()
        {
            _originalValue = _value;
        }
    }
