    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    [assembly:System.CLSCompliant(true)]
    [assembly: ComVisible(true)]
    // The following GUID is for the ID of the typelib if this project is exposed to COM
    [assembly: Guid("7d9c5cd3-73d4-4ab1-ba98-32515256c0b0")]
    namespace Cheeso.ComTests
    {
        [Guid("7d9c5cd3-73d4-4ab1-ba98-32515256c0b1")]
        public class TestReply
        {
            public string salutation;
            public string name;
            public string time;
        }
        [Guid("7d9c5cd3-73d4-4ab1-ba98-32515256c0b2")]
        public class TestObj
        {
            // ctor
            public TestObj () {}
            public TestReply SayHello(string addressee)
            {
                return SayHello(addressee, "hello");
            }
            public TestReply SayHello(string addressee, string greeting)
            {
                string x = String.Format("{0}, {1}!", greeting, addressee);
                Console.WriteLine("{0}", x);
                TestReply r = new TestReply
                {
                    salutation = greeting,
                    name = addressee,
                    time = System.DateTime.Now.ToString("u")
                };
                return r;
            }
        }
    }
