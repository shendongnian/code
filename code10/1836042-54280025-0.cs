csharp
public class Company
{
  public string Name { get; set; }
  public IList<Person> Employees { get; set; }
}
public class Person
{
  public string Name { get; set; }
  public string Title { get; set; }
  public Person Manager { get; set; }
}
Then you can use a JSON serializer. JSON.NET is the most popular by far and supports many customizable behaviors, as well as references. In the example above, you wouldn't want a deep duplication of a Person that was a Manager, and their Manager, and so on. So JSON.NET supports references. Documentation is available at https://www.newtonsoft.com/json.
However, if you're not going to use a NoSQL database, you're also missing out on backup capabilities, transactions, etc. You should think about creating a backup of the previous 1 or more files before saving a new one, deleting older ones as necessary. Or just use a NoSQL database that runs locally (there are many options) and maybe even has online sync capabilities if you want to support multiple users.
