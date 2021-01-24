    class a
    {
        public void callMe()
        {
            // Base logic
        }
    }
    class b : a
    {
        public new void callMe()
        {
            // This Will call Base method
            base.callMe();
            // Derived Logic
        }
    }
