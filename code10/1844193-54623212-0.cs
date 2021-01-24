    public class A
    {
        public int X { get; set; }
    
        public string Y { get; set; }
    
        public object this[string name]
        {
            get => GetType().GetProperty(name).GetValue(this, null);
            set
            {
                GetType().GetProperty(name).SetValue(this, value);
            }
        }
    }
