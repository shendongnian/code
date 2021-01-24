    public class Person
    {
       public int Id { get; set; } 
       public string Name{ get; set; }
       public ICollection<PersonRelative> PersonRelatives {get;set;}
    }
