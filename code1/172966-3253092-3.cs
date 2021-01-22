    [Test]
    public void SomeMethodShouldReturnSomething() { 
       Foobar foobar = new Foobar();
       string actual;
       foobar.SomeMethod(ref actual);
       Assert.AreEqual("I'm the test your tests could smell like", actual);
    }
