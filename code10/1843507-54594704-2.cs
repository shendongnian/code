    public class Table1
    {
        public int Id { get; set; }
        public virtual ICollection<Table2> Table2Objects { get; set; }
        [NotMapped]
        public virtual Table2WithUniqueColumn456 Table2Object456 
        {
            get { return Table2Objects.FirstOrDefault(x => x.UniqueColumnAtTable2ForGivenTable1Id == 456; }
        }
    }
