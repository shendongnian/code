    public class Parent 
    {
      public int Id { get; set; }
      [InverseProperty("Parent")]
      public ICollection<Child> Children { get; set; }
    }
