    public class myClass
    {
        public bool TestMethod(string input)
        {
            return true;
        }
        public bool Method1(Func<string, bool> methodName)
        {
            return true;
        }
        public void newMthod()
        {
            Method1(TestMethod);
        }
    }
