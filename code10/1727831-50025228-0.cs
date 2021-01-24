    public class BpsModel {
        [Key]
        [Column("my_custom_column_name")]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Reviewers { get; set; }
        public List<Person> Modelers { get; set; }
    }
