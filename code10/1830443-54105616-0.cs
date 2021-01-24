    public class Student
    {
       [Key, Column("Id")]
       public int Id { get; set; }
       public string Name { get; set; }
    }
