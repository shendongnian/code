lang-csharp
enum Gender
{
    Male,
    Female
}
abstract class Person
{
    public string Name { get; set; }
    public abstract Gender Gender { get; }
}
class MalePerson : Person
{
    public override Gender Gender { get { return Gender.Male; } }
    public MalePerson()
    { ... }
}
class FemalePerson : Person
{
    public override Gender Gender { get { return Gender.Female; } }
    public FemalePerson()
    { ... }
}
In this way you are enforcing that the user must instantiate a Person using either the Male default constructor or the Female default constructor.
Serialization would also be able to preserve the sub-types and use default constructors without resulting in an incorrect default value.
