    class Person
     {
      public int id {get;set;}
      public string   Name {get; set;}
     }
     class Persons
     {
	   public Persons()
	   {
		   PersonsList=new List<Person>();
	   }  
       public List<Person> PersonsList {get;set;}
       public Person this[int index]
       {
         get {  return PersonsList[index];  }
         set { 
			 PersonsList[index].id=value.id;
             PersonsList[index].Name=value.Name;
             }
       }
     }
