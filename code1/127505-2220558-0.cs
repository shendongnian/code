    [Test]
    public void Test()
    {
        var classMock = MockRepository.GenerateMock<MyClass>();
        var linkedMock = MockRepository.GenerateStub<MyClass>();
        classMock.Expect(c => c.MyMethod(linkedMock));
        classMock.MyMethod(linkedMock);
        classMock.AssertWasCalled(c => c.MyMethod(linkedMock));
    }
    public class MyClass
    {
        public virtual void MyMethod(MyClass linkedClass)
        {
            Console.WriteLine("MyMethod is called");
        }
    }
