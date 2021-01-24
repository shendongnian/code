[TestMethod]
public void A_test()
{
    var myClass = new MyClass(new LoggerConfiguration().WriteTo.TestCorrelator().CreateLogger());
    using (TestCorrelator.CreateContext())
    {
        myClass.LogInit();
        TestCorrelator.GetLogEventsFromCurrentContext()
            .Should().ContainSingle()
            .Which.MessageTemplate.Text
            .Should().Be("{@myObject}");
    }
}
