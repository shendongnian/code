    class MyClass
    {
        public string this[string key]
        {
            get { return GetValue(key); }
            set { SetValue(key, value); }
        }
    }
