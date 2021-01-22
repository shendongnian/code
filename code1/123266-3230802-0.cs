    [Test]
    public void Should_create_new_Thing_for_each_old_Thing()
    {
      // -----
      // arrange
  
      // hardcode results from old system provider
      List<Thing> oldThings = new List<Thing> { ... };
      // old system provider
      var oldProvider = MockRepository.GenerateStub<IOldSystemProvider>();
      oldProvider.Stub(m=>m.GetThings()).Return(oldThings);
      // new system provider
      var newProvider = MockRepository.GenerateStub<INewSystemProvider>();
      // service object
      var svc = new MyService(oldProvider, newProvider);
      //-----------
      // act
      var result = svc.CopyThings();
      //------------
      // assert
      oldThings.ForEach(thing => 
                        newProvider.AssertWasCalled(prov => prov.CreateThing(thing)));
    }
