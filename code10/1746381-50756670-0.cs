    public class MyModel
    {
        [Key]
        public int ModelId { get; set; }  // auto filled, ignore where you don't need it
        //[Index(IsUnique = false)] -- not needed
        public int Id { get; set; }       
        public DateTime Date{ get; set; }
        ...
