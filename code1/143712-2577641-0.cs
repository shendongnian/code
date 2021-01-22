    public void Throw()
    {
        throw new MyException();
    }
    
    public void CallThrow()
    {
        Throw();
    }
    
    [Test]
    public void GetThrowingMethodName()
    {
        try
        {
            CallThrow();
            Assert.Fail("Should have thrown");
        }
        catch (MyException e)
        {
            MethodBase deepestMethod = new StackTrace(e).GetFrame(0).GetMethod();
            string deepestMethodName = deepestMethod.Name;
            Assert.That(deepestMethodName, Is.EqualTo("Throw"));
        }
    }
