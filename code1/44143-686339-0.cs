        static void SomeMethod(string x, string y) { }
        static void Main()
        {
            string SecondArg;
            SomeMethod("foo", SecondArg = "bar");
        }
