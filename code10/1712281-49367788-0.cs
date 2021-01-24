    class Derived : bbase
    {
        public override int id
        {
            get
            {
                return base.id;
            }
            set
            {
                base.id = value;
            }
        }
    }
