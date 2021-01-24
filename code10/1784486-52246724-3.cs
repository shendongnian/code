    public class Program
    {
	    public static void Main()
	    {
	      Persons pp=new Persons();
		  Person p=new Person() { id=1, Name="test"};
		  Person p1=new Person() { id=2, Name="test1"};
	      pp.PersonsList.Add(p);
		  pp.PersonsList.Add(p1);
		
		  pp[1]=new Person(){id=3,Name="tye"};
	      Console.WriteLine(pp[1].Name);
       }
     }
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
 
