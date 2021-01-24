    class Family   
    {
     public int FamilyId { get; set; }
     public string Nickname { get; set; }
     public Adults father { get; set; }
     public Adults mother { get; set; }
     public List<Person> Children = new List<Person>();
    }
