    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public class A
        {
            public string Username { get; set; }
            public bool   IsOK     { get; set; }
        }
        public class B: A
        {
            public string test { get; set; }
        }
        public class C: B
        {
            public string test2 { get; set; }
        }
        static class Program
        {
            public static void Main()
            {
                var     a        = new B() { Username = "User1", IsOK = false };
                var     b        = new B() { Username = "user2", IsOK = false };
                var     c        = new C() { Username = "admin", IsOK = true };
                List<B> bclasses = new List<B>() { a, b, c };
                // I want to filter out username is user2 or IsOK is true
                var username = "user2";
                bool predicate(A x) => x.IsOK || x.Username == username; // <=== Here is the predicate.
                var select = bclasses.Where(predicate).ToList();
            }
        }
    }
