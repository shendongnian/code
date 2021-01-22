    class ThingWrapper
    {
        public Thing Thing {get; set;}
        
        public int SomeProperty
        {
            get
            {
                return int.Parse(this.Thing.SomeProperty);
            }
            set
            {
                Thing.SomeProperty = value.ToString();
            }
        }
    }
