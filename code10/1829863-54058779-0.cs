    public class MyModel : IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
