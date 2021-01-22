    class Derived : IDerived 
    {
        #region IDerived Members
        public string Foo { get; set; }
        #endregion
        #region IBase Members
        public DateTime LastRunDate {get;set;}
        #endregion
    }
