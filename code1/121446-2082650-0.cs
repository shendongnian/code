    public class Class1
    {
        public int Method1(string input)
        {
            //... do something
            return 0;
        }
        public int Method2(string input)
        {
            //... do something different
            return 1;
        }
        public bool RunTheMethod(Func<string, int> myMethodName)
        {
            //... do stuff
            int i = myMethodName("My String");
            //... do more stuff
            return true;
        }
        public bool Test()
        {
            return RunTheMethod(Method1);
        }
    }
