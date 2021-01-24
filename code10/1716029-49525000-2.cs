    class B {
        private configObject cfg;
        public configObject config {
            get {
                 if (cfg == null)
                     cfg = new configObject
                     {
                         property1 = value1
                         property2 = value2;
                         property3 = null
                         property4 = false;
                     };
                     return cfg;
                 }
             set { cfg = value; }
    }
