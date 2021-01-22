    [Test]
    public void SomeMethodShouldReturnSomething() { 
       Foobar foobar = new Foobar();
       var actual = foobar.SomeMethod();
       Assert.AreEqual("I'm the test your tests could smell like", actual);
    }
