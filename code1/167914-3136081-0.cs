    public class B
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual A FK_ToA { get; set; }
    }
