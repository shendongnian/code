    internal delegate void EventHandler(Car car, Random rnd);
    internal class Car
    {
        internal string CarName;
        internal virtual void SetName()
        {
            this.CarName = "car";
        }
        //Edit : As Mrinal Kamboj suggested in comments below
        //here keeping event Buy as private will prevent it to be used from external code
        private event EventHandler Buy;
        //while having EventAccessros internal (or public) will expose the way to subscribe/unsubscribe it
        internal event EventHandler BuyAccessor
        {
            add 
            {
                lock (this)
                {
                    Buy += value;
                }
            }
            remove
            {
                lock (this)
                {
                    Buy -= value;
                }
            }
        }
        internal virtual void OnBuy(Random rnd)
        {
            if (Buy != null)
                Buy(this, rnd);
        }
    }
    internal class Sport: Car
    {
        LicenseService m_ls;
        internal Sport(LicenseService ls)
        {
            this.m_ls = ls;
            this.BuyAccessor += ls.GenerateLicense;
            SetName();
        }
        internal override void SetName()
        {
            this.CarName = "Sport";
        }
    }
    internal class City: Car
    {
        LicenseService m_ls;
        internal City(LicenseService ls)
        {
            this.m_ls = ls;
            this.BuyAccessor += ls.GenerateLicense;
            SetName();
        }
        internal override void SetName()
        {
            this.CarName = "City";
        }
    }
