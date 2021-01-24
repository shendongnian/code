    public class Item : Entity{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id{get;set;}
    }
