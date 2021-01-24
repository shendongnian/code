    public class SubordinateItem : ObservableObject
    {
        private String _value = default(String);
        public SubordinateItem() { }
        public SubordinateItem(string subordinate)
        {
            this._value = subordinate;
        }
        public String Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    Set(ref _value, value);
                }
            }
        }
    }
