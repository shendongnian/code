    using Rhino.Mocks;
    public class TestTest {
     [Test]
     public void FooTest()
     {
       var mock = new MockRepository().PartialMock<Test>();
       mock.Expect(t => t.GetDataset2());
       mock.GetDataset((RandomBoolean)null);
        
     }
    }
