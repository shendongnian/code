    class b : a
    {
        [Browsable(false)]
        public override int item1
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }
    }
