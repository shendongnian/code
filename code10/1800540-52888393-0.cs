    [Test]
    public void Test()
    {
        
        var a = 1;
        var b = 2;
        var c = 1;
        var context = new AssertionScope();
        try
        {
            throw new Exception("Test");
        }
        catch (Exception e)
        {
            context.FailWith(e.ToString());
        }
        var strings = context.Discard();
        Console.WriteLine(strings.StringJoin(","));
        context.Succeeded.Should().BeFalse();
        
        var someOtherContext = new AssertionScope();
        try
        {
            c.Should().Be(a);
        }
        catch (Exception e)
        {
            someOtherContext.FailWith(e.ToString());
        }
        var discard = someOtherContext.Discard();
        Console.WriteLine(discard.StringJoin(","));
        someOtherContext.Succeeded.Should().BeTrue();
    }
