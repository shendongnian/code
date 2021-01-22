    class Test
    {
        public int AddStrings(string a, string b)
        {
            return int.Parse(a) + int.Parse(b);
        }
    
        static void Main()
        {
            var test = new Test();
            var methodInfo = test.GetType().GetMethod("AddStrings");
            // note the first extra parameter of the Func, is the owner type
            var delegateType = typeof(Func<Test, string, string, int>);
            var del = Delegate.CreateDelegate(delegateType, null, methodInfo);
                
            var result = (int)del.DynamicInvoke(test, "39", "3");
        }
    }
