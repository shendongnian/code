    [Test()]
    public void Confirm_Yes_Test()
    {
        var cp = new ConfirmationProvider(new StringReader("y"), Console.Out);
        Assert.IsTrue(cp.Confirm("operation"));
    }
    [Test()]
    public void Confirm_No_Test()
    {
        var cp = new ConfirmationProvider(new StringReader("n"), Console.Out);
        Assert.IsFalse(cp.Confirm("operation"));
    }
