csharp
public class SystemUnderTest
{
    public FragileStructCantChange myStruct { get; set; }
    // This Func can be overridden for testing purposes
    public Func<string> LongRunningMethod;
    public SystemUnderTest() {
        LongRunningMethod = () => myStruct.LongRunningMethod();
    }
    public string MethodUnderTest()
    {
        // Call the indirect Func instead of referencing the struct directly
        if (LongRunningMethod() == "successful")
            return "Ok";
        else
            return "Fail";
    }
}
public class Tests
{
    [Fact]
    public void TestingSideDoor()
    {
        var sut = new SystemUnderTest();
        // Override the func to supply any test data you want
        sut.LongRunningMethod = () => "successful";
        Assert.Equal("Ok", sut.MethodUnderTest());
    }
}
Another option is to use a virtual method, which can be faked either by a subclass or a mocking framework ([Moq](https://github.com/moq/moq4), in this example)
public class SystemUnderTest
{
    public FragileStructCantChange myStruct { get; set; }
    // This method can be overridden for testing purposes
    public virtual string LongRunningMethod()
        => myStruct.LongRunningMethod();
    public string MethodUnderTest()
    {
        // Call the indirect method instead of referencing the struct directly
        if (LongRunningMethod() == "successful")
            return "Ok";
        else
            return "Fail";
    }
}
public class Tests
{
    [Fact]
    public void TestingSideDoor()
    {
        var sut = new Mock<SystemUnderTest>();
        // Override the method to supply any test data you want
        sut.Setup(m => m.LongRunningMethod())
            .Returns("successful");
        Assert.Equal("Ok", sut.Object.MethodUnderTest());
    }
}
I won't claim that either of these options is pretty, and I will concede that the indirection adds a bit of computational overhead (although, likely no more than an interface would). I'd also think very hard before putting this sort of backdoor into a shared library. An interface is usually preferable if it works for you.
This sort of thing works, though, and I think it can be a fair compromise when you're faced with test-unfriendly code that you don't want to invasively refactor.
