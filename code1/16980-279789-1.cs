public void Foo()
{
    Bar(1, 2, "Hello", "World"); //no exception
    Bar(1, 2, "Hello", null); //exception
    Bar(1, 2, null, "World"); //exception
}
public void Bar(int x, int y, string someString1, string someString2)
{
    //will also work with comments removed
    //x.ThrowIfNull();
    //y.ThrowIfNull();
    someString1.ThrowIfNull();
    someString2.ThrowIfNull();
    //Do something incredibly useful here!
}
