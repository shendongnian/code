    internal delegate void EventHandler(Car car);
    internal class Car
    {
        internal string CarName;
        internal virtual void SetName()
        {
            this.CarName = "car";
        }
        internal event EventHandler Buy;
        internal virtual void OnBuy()
        {
            if (Buy != null)
                Buy(this);
        }
    }
    internal class Sport: Car
    {
        LicenseService m_ls;
        internal Sport(LicenseService ls)
        {
            this.m_ls = ls;
            this.Buy += ls.GenerateLicense;
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
            this.Buy += ls.GenerateLicense;
            SetName();
        }
        internal override void SetName()
        {
            this.CarName = "City";
        }
    }
