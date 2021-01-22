    public class MyClass
    {
        Dictionary<string, Action> myDictionary;
        public MyClass()
        {
            BuildMyDictionary();
        }
        private Dictionary<int, Action<int, int>> BuildMyDictionary()
        {
            myDictionary.Add("x", DoSomethingX);
            myDictionary.Add("y", DoSomethingY);
            myDictionary.Add("z", DoSomethingZ);
            myDictionary.Add("w", DoSomethingW);
        }
        public void DoStuff()
        {
            string whatever = "x"; //Get it from wherever
            //instead of switch
            myDictionary[t]();
        }
    }
