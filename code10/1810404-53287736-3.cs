    public class Person
    {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime BornOn { get; set; }
      public boolean IsMarried { get; set; }
      public string FullName 
      {
        get 
        {
         return $"{FirstName} {LastName}";
        }
      }
    }
