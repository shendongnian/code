    struct VolatileBoolean {
        private volatile Boolean value;
        public Boolean Value {
            get { return value; }
            set { this.value = value; }
        }
    }
    VolatileBoolean[] arrayOfVolatileBooleans;
    public void SomeMethod() {
        if (arrayOfVolatileBooleans[4].Value)
            DoSomething();
    }
