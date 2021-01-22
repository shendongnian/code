    public class MyHeaderCollection:WebHeaderCollection
    {
        public new void Set(string name, string value)
        {
            AddWithoutValidate(name, value);
        }
        //or
        public new string this[string name]
        {
            get { return base[name]; }
            set { AddWithoutValidate(name, value); }
        }
    }
