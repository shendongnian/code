    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
        static void Main()
        {
            TestUrl("/hello-world/blah/");
            TestUrl("/hello-world/blah/234");
            TestUrl("/hello-world/234");
            TestUrl("/hello-world/234/blah");
            TestUrl("/hello-world/12/34");
        }
        
        static void TestUrl(string url)
        {
            string transformed = Regex.Replace(url, @"/\d*$", "");
            Console.WriteLine("{0} => {1}", url, transformed);
        }
    }
