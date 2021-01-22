C#
class Person
{
    // Copy constructor 
    public Person(Person previousPerson)
    {
        Name = previousPerson.Name;
        Age = previousPerson.Age;
    }
    // Copy constructor calls the instance constructor.
    public Person(Person previousPerson)
        : this(previousPerson.Name, previousPerson.Age)
    {
    }
    // Instance constructor.
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public int Age { get; set; }
    public string Name { get; set; }
}
Referenced the [Microsoft C# Documentation under Constructor][1] for this example having had this issue in the past.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-write-a-copy-constructor
