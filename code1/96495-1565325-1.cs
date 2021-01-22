    class TaxIncrease
    {
        public int Tax { get; set; }
        public int Increase { get; set; }
    }
    
    public IQueryable<TaxIncrease> listAll() {
        ModelQMDataContext db = new ModelQMDataContext();
        return from t in db.tax
               select new TaxIncrease {Tax = t.tax1, Increase = t.increase};
    }
