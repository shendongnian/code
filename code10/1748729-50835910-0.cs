    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace UnitTests_ALL
    {
        [TestClass]
        public class UnrelatedTests
        {
    
    
            [TestMethod]
            public void InterfaceTest()
            {
                bar x = new bar { result = "Hi bar it's " };
                bar2 xx = new bar2 { beforeResult = DateTime.Now };
    
                Console.WriteLine(Method(x));
                Console.WriteLine(Method(xx));
    
            }
    
            public string Method<T>(T f) where T : Ibar
            {
                return f.result;
            }
    
        }
    
        public class foo
        {
            public foo(Ibar fooBar)
            {
                data = fooBar;
            }
            Ibar data { get; set; }
        }
        public interface Ibar
        {
            int id { get; set; }
            string result { get; set; }
        }
    
        public class bar : Ibar
        {
            public int id { get; set; }
            public string result { get; set; }
        }
    
    
        public class bar2 : Ibar
        {
            public int id { get; set; }
            public DateTime beforeResult
            {
                set { result = value.ToString(); }
            }
            public string result { get; set; }
        }
    
        public static class Extensions
        {
    
            public static string doSomething(this bar b)
            {
                return b.result;
            }
    
            public static string doSomething(this bar2 b)
            {
                b.result = b.result;
                return b.result;
            }
        }
    }
