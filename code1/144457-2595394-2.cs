    [Test]
    public void Find_returns_nothing_if_predicate_always_false()
    {
       var predicateStub = MockRepository.GenerateStub<Func<Entity,bool>>();
       predicateStub.Stub(x => x(Arg<Entity>.Is.Anything)).Return(false);
    
       var repository = new Repository();
       var entities = repository.Find(predicateStub);
    
       Assert.AreEqual(0, entities.Count(), 
          "oops, got results while predicate always returns false");
       predicateStub.AssertWasCalled(x => x(Arg<Entity>.Is.Anything));
    }
