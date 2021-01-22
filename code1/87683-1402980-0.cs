    public IEnumerable<int> DoFoo() {
       Console.WriteLine("doing foo");
       yield return 10;
    }
    [Test]
    public void TestMethod()
    {
        var x = DoFoo();
        Console.WriteLine("foo aquired?");
        Console.WriteLine(x.First());
    }
