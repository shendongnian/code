    // test business logic without web service! yay!
    [Test]
    public void Test_DoSomething ()
    {
        MyService service = new MyService ();
        string actual = service.DoSomething ();
        // verify results
    }
