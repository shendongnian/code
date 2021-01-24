    public class ClassUnderTest {
        public void SampleMethod(FooBarObject fooBarObject) {
            try { 
                fooBarObject.Name = "Never forget a towel";
                fooBarObject.Number = 42;
            }
            catch (NullReferenceException){}
        }
    }
    
    [Test]
    public void Given_A_Class_Under_test_When_Calling_The_Sample_Method_It_Should_Not_Throw() {
        var sut = new ClassUnderTest();
    
        Assert.DoesNotThrow(() => sut.SampleMethod(null));
    }
