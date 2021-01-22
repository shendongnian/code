       class RefRefExample
    {
        static void Method(ref string s)
        {
            s = "changed";
        }
        static void Main()
        {
            string str = "original";
            Method(ref str);
            // str is now "changed"
        }
    } 
