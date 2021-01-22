class MyClass : IDisposable
{
    void Dispose()
    {}
}
using(MyClass obj = Man.GetObj())
{
    obj.DoSomething();
}// obj.Dispose() will be called when the object goes out of scope.
