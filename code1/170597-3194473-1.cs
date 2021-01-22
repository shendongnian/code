    [Test]
    public void List_returns_PartialView_for_Ajax_request()
    { 
       // arrange system under test and stubs
       var request = MockRepository.GenerateStub<IRequest>();
       request.Stub(x => x.IsAjaxRequest).Returns(true);
       var myObject = new MyClass(request);
       // act
       object result = myObject.List(0);
       // assert
       Assert.IsTrue(result is PartialView);
    }
