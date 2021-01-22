    class MyShim {
        private readonly FinancialInstitution inner;
        public MyShim(FinancialInstitution inner) {this.inner = inner;}
        public string EntityCode { get {return inner.EntityCode;}}
        public string EntityNameDesc { get {return inner.EntityNameDesc;}}
        public string EntityCaption {
            get {return "(" + EntityCode + ") - " + EntityNameDesc;
        }
    }
