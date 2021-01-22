    class X
    {
        public void SetInT(double newInT)
        {
            if (newInT != _inT)
            {
                _inT = newInT;
                Changed();//includes delegate call; potentially expensive
            }
        }
        private void InitSetter(double newInT)
        {
            if (newInT != _inT)
                _inT = newInT;
        }
        private double _inT;
        
        public double InT
        {
            get { return InT; }
            set { InitSetter(value); }
        }
    }
