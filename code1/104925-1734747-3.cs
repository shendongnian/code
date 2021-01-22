    [Test]
    public void SortTest()
    {
        var persons = new List<Person>
                          {
                              new Person { Age = 0 },
                              new Person { Age = 2 },
                              new Person { Age = 1 }
                          };
    
        persons.Sort();
    
        Assert.AreEqual(0, persons[0].Age);
        Assert.AreEqual(1, persons[1].Age);
        Assert.AreEqual(2, persons[2].Age);
    }
