    class DataPoint
    {
        public int Id {get; set;} // primary key
        ...
        public virtual ICollection<ConstraintFilter> ConstraintFilters {get; set;}
    } 
