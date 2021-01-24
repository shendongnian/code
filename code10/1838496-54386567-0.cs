    public class Foo
    {
      public int Id { get; set; }
      // Props for easy 1-many relationship.
      public int BarId { get; set; }
      public virtual Bar Bar { get; set; }
      //****** THE CHANGED BIT ******
      public ICollection<Bar> BarsForWhichThisIsTheSpecialFoo { get; set; }  
      //****** THE CHANGED BIT ******
    }
    public class Bar
    {
      public int Id { get; set; }
      // Prop for easy 1-many relationship.
      public virtual ICollection<Foo> Foos { get; set; }
      // Props for hard 1-0..1 relationship.
      public int? SpecialFooId { get; set; }
      public virtual Foo SpecialFoo { get; set; }
    }
