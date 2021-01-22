    [Table("Customer", Schema = "DBSchema")]
    public class Customer{
    
        [Column("Date", TypeName = "SmallDateTime")]   
        public DateTime Date{ get; set; }
    
    }
