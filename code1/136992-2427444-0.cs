        protected new bool DesignMode
        {
            get
            {
                if (base.DesignMode)
                    return true;
                return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            }
        }
