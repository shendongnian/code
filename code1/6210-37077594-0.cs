    [TestMethod]
    public void BraceEscapingTest()
    {
        var result = String.Format("Foo {{0}}", "1,2,3");  //"1,2,3" is not parsed
        Assert.AreEqual("Foo {0}", result);
    
        result = String.Format("Foo {{{0}}}", "1,2,3");
        Assert.AreEqual("Foo {1,2,3}", result);
    
        result = String.Format("Foo {0} {{bar}}", "1,2,3");
        Assert.AreEqual("Foo 1,2,3 {bar}", result);
    
        result = String.Format("{{{0:N}}}", 24); //24 is not parsed, see @Guru Kara answer
        Assert.AreEqual("{N}", result);
    
        result = String.Format("{0}{1:N}{2}", "{", 24, "}");
        Assert.AreEqual("{24.00}", result);
    
        result = String.Format("{{{0}}}", 24.ToString("N"));
        Assert.AreEqual("{24.00}", result);
    }
