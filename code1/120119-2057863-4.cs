    class Program
    {
        static void Main(string[] args)
        {
            ClassWithSimpleMethods classWithSimpleMethods = new ClassWithSimpleMethods();
            ClassWithDelegateMethods classWithDelegateMethods = new ClassWithDelegateMethods();
            //The call is ambiguous between the following methods or properties: 
            //'test.ClassWithDelegateMethods.Method(System.Func<int,int>)' 
            //and 'test.ClassWithDelegateMethods.Method(test.ClassWithDelegateMethods.aDelegate)'
            classWithDelegateMethods.Method(classWithSimpleMethods.GetX);
        }
    }
    class ClassWithDelegateMethods
    {
        public delegate string aDelegate(int x);
        public void Method(Func<int> func) { /* do something */ }
        public void Method(Func<string> func) { /* do something */ }
        public void Method(Func<int, int> func) { /* do something */ }
        public void Method(Func<string, string> func) { /* do something */ }
        public void Method(aDelegate ad) { }
    }
    class ClassWithSimpleMethods
    {
        public string GetString() { return ""; }
        public int GetOne() { return 1; }
        public string GetX(int x) { return x.ToString(); }
    } 
