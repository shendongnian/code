    public class Person 
    {
	
	  public DateTime BirthDay {get;}
	  public string LastName {get;}
	  public string FirstName {get;}
	
	  public Person(string lastName,  string firstName, DateTime birthDay) => (LastName, FirstName, BirthDay) = (lastName, firstName, birthDay);
	
	  public override string ToString() => $"{FirstName} {LastName} {BirthDay.Month}";
    }
