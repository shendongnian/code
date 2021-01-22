    [Test]
    public void SomeTest()
    {
       MockRepository mocks = new MockRepository();
       ISomeClass mockSomeClass = mocks.StrictMock<ISomeClass>();
       using(mocks.Record())
       {
          using(mocks.Ordered())
          {
             Expect.Call(MockSomeClass.SomeProp).Return(false);
             Expect.Call(delegate{MockSomeClass.SomeMethod();});
             Expect.Call(MockSomeClass.SomeProp).Return(true);
          }
       }
    }
