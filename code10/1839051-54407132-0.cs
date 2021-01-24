interface IHaveName
{
  string Name { get; set;}
}
class Class1 : IHaveName
{
   ...
}
private T getMyClass<T>(string name) where T : new(), IHaveName
