    public class SomeTypeCollection: ObservableCollection<SomeType>
    {
        public SomeTypeCollection() : base() { }
        public SomeTypeCollection(IEnumerable<SomeType> IEObj) : base(IEObj) { 
     }
    }
   
    public ConsumeIlist
    {
        public SomeTypeCollection OSomeTypeCllt { get; set; }
        MyDbContext _dbCntx = new MyDbContext();
         public ConsumeIlist(){
              OSomeTypeCllt = new 
       SomeTypeCollection(_dbCntx.ComeTypeSQLTable);
         }
    }
