    //no explicit foreign key
    public class Sims
    {
        public int ID { get; set; }
        public Users Users { get; set; }
    }
    //explicit foreign key but EF works it out via convention
    public class Sims
    {
        public int ID { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
    //explicitly named foreign key which is named differently from 
    //convention so needs to be pointed at.  note nameof() operator
    //which will give a compiler error should you rename it, so is
    //better than a magic string
    public class Sims
    {
        public int ID { get; set; }
        
        [ForeignKey(nameof(Users))]
        public int MyUsersFkField { get; set; }        
        public Users Users { get; set; }
    }
