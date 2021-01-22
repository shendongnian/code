    using Moq;
    using NUnitFramework;
        
    namespace MyNameSpace
        {
            [TestFixture]
            public class MyClassTests
            {
        
                [Test]
                public void TestGetSomeString()
                {
                    const string EXPECTED_STRING = "Some String!";
       
                    Mock<IDependance> myMock = new Mock<IDependance>();
                    myMock.Expect(m => m.GiveMeAString()).Returns("Hello World");
    
                    MyClass myobject = new MyClass();
    
                    string someString = myobject.GetSomeString(myMock.Object);
        
                    Assert.AreEqual(EXPECTED_STRING, someString);
                    myMock.VerifyAll();
        
                }
        
            }
        
            public class MyClass
            {
    
                public virtual string GetSomeString(IDependance objectThatITalkTo)
                {
                    return objectThatITalkTo.GiveMeAString();
                }
            }
            public interface IDependance
            {
                string GiveMeAString();
            }
        }
