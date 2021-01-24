csharp
public class Person
{
    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public override string ToString() => $"FirstName {FirstName}{Environment.NewLine}LastName {LastName}{Environment.NewLine}Age {Age}";
}
Then you call ToString() on your instance:
csharp
Person person = new Person("Miles", "Morales", 18);
Console.WriteLine(person.ToString());
And this will print out:
 
FirstName Miles  
LastName Morales  
Age 18  
