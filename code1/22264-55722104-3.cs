// This class is used only for test and purpose is make SomeMethod mockable
public abstract class DummyClass : SomeClass
{
    public virtual void DummyMethod() => base.SomeMethod();
}
Then you could setup `DummyMethod()` to propagate the call by setting `CallBase` flag, e.g.
//Arrange
var mock = new Mock<DummyClass>();
mock.Setup(m => m.DummyMethod()).CallBase();
//Act
mock.Object.SomeMethod();
//Assert
mock.Verify(m => m.SomeOtherMethod(), Times.Once);
  [1]: https://stackoverflow.com/a/347907/3311799
