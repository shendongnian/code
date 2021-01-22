    class TwitterItem
    {
        private string myValue = "default value";
        public string Value1
        {
            get { return myValue; }
            set { myValue = value; }
        }
        public string Value2
        {
            get { return myValue; }
            set { myValue = value; }
        }
        public string Value3
        {
            get { return myValue; }
            set { myValue = value; }
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) return true;
            Type type = typeof(TwitterItem);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (false == property.GetValue(this, null).Equals(property.GetValue(obj, null)))
                    return false;
            }
            return true;
        }
    }
