    public class MenuItem 
    {
        [Key]
        public Int MenuID{ get; set; }
        public string ItemName { get; set; }
        public string Itemdesrciption { get; set; }
        public Int ItemAmount{ get; set; }
    
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]      
        public string ItemPrice
        {
            get { return /* do your sum here */ }
            private set { /* needed for EF */ }
        }
    }
