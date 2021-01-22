    delegate bool propDelegate();
    delegate void methodDelegate();
    private bool m_MockPropValue = false;
    
    [Test]
    public void SomeTest()
    {
       MockRepository mocks = new MockRepository();
       ISomeClass mockSomeClass = mocks.StrictMock<ISomeClass>();
       using(mocks.Record())
       {
          SetupResult.For(MockSomeClass.SomeProp).Do(new propDelegate(delegate
          {
             return this.m_MockPropValue;
          }));
          Expect.Call(delegate{MockSomeClass.SomeMethod();}).Do(new methodDelegate(delegate
          {
             this.m_MockPropValue = true;
          }));
       }
    }
