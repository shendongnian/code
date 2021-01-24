    namespace MyNamespace {
        public class Foo {
            public string GetString() => @"Hello
    World"; // Returns a string that looks like
            // Hello
            // World
            public string GetString2() => @"Hello
                World"; // Returns a string that looks like
                        // Hello
                        //             World
        }
    }
