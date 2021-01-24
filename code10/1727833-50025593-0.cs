    public class BpsModel {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("ReviewerId")]
        public int ReviewerId { get; set; }
        public Person Reviewers { get; set; }
        [ForeignKey("ModelerId")]
        public int ModelerId { get; set; }
        public Person Modelers { get; set; }
    }
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
       public ICollection<BpsModel> BpsModel{ get; set; }
    }
