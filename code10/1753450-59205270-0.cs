public class BaseEntity
{
    public int ID { get; set; }
}
public partial class Customer : BaseEntity
{
}
public partial class Customer
{
    // ID is provided from the base!
    //public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
}
Using `virtual` properties becomes dangerous as a design choice because there is a gray area where [auto-properties][2] might or might not be implemented in the base or other inheriting classes. If all classes in the inheritance tree use auto-properties, then there is no issue, however when any traditional getter or setter that is not _auto_ is overriden, if the override does not call back to the base implementation, then any references to the fields or placeholders that were implemented in the base will not have their values set.
- which is pretty close to the situation that OP has raised. 
> Specifically with ORM tools like EF, I would caution making the ID property virtual or abstract at all.
>> The ID is too important to leave to chance.
>> If you are using virtual properties to support Lazy Loading, in EF you only need to make navigational properties virtual to support this, not every property on a class.
  [1]: https://stackoverflow.com/a/51035496/1690217
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
