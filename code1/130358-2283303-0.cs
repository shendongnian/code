class MyClass
{
    public int x;
    public static int y;
    public static void TestFunc()
    {
        x = 5; // Invalid, because there is no 'this' context here
        y = 5; // Valid, because y is not associated with an object instance
    }
    public static void TestFunc2(MyClass instance)
    {
        instance.x = 5; // Valid
        instance.y = 5; // Invalid in C# (valid w/ a warning in VB.NET)
    }
}
