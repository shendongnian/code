    [Test]
    public void Find_returns_nothing_if_predicate_always_false()
    {
       bool predicateCalled = false;
       Func<Entity,bool> predicate = x => { predicateCalled = true; return false; };
    
       var repository = new Repository();
       var entities = repository.Find(predicate);
    
       Assert.AreEqual(0, entities.Count(), 
          "oops, got results while predicate always returns false");
       Assert.IsTrue(predicateCalled, "oops, predicate was never used");
    }
