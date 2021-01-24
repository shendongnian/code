    public class Primary_Class
    {
        [Key]
        public int pkey { get; set; }
        public string Misc { get; set; }
    }
    public class dependent_Class
    {
        [Key]
        public int dkey { get; set; } //*column 1 of Primary key*/
        [ForeignKey("Primary_Class")]
        [Column(Order = 1)]
        public int pkey { get; set; }  //*Cloumn 2 of PK as well as FK to Primay_Class*
        public string data{get; set;}
    }
