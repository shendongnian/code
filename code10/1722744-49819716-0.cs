    class Bar
    {
       Random random = new Random();
       Array Foos = Enum.GetValues(typeof(Foo));
        private Foo _type;
        public Foo type
        {
            get { return _type; }
            set
            {
                _type = (Foo)Foos.GetValue(random.Next(3));
            }
        }
    }
