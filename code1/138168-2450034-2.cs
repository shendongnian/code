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
        
        private double _inT;
        
        public double InT
        {
            get { return InT; }
            set
            {
                if (newInT != _inT)
                    _inT = newInT
            }
        }
    }
