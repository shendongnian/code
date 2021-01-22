    [TestMethod]
    [ExpectedException(typeof(ArgumentException),
        "A userId of null was inappropriately allowed.")]
    public void NullUserIdInConstructor()
    {
       LogonInfo logonInfo = new LogonInfo(null, "P@ss0word");
    }
