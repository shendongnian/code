    public class MyTest
    {
        public class TestNow : INowResolver
        {
           public DateTime Now {get;set;}
           public DateTime GetNow() => Now;
        }
        [Test]
        public void MyTest()
        {
           var resolver = new TestNow { Now = new DateTime(2018,1,1) }
           var testClass = new TestClass(resolver);
           
        }
    }
