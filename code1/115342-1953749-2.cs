    [TestFixture]
    public class When_calling_Foo
    {
        [Test]
        public void Should_call_Dispose()
        {
            IMyDisposableClass disposable = MockRepository
                                            .GenerateMock<IMyDisposableClass>();
            Stuff stuff = new Stuff(disposable);
            stuff.Foo();
            disposable.AssertWasCalled(x => x.Dispose());
        }
    }
