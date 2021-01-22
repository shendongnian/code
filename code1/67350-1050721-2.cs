    public class MyClass
    {
        Dictionary<int, Action<int, int>> myDictionary;
        //These could have only static methods also
        Group1Object myObject1;
        Group2Object myObject2;
        public MyClass()
        {
            //Again, you wouldn't have to initialize if the functions in them were static
            myObject1 = new Group1Object();
            myObject2 = new Group2Object();
            BuildMyDictionary();
        }
        private Dictionary<int, Action<int, int>> BuildMyDictionary()
        {
            InsertGroup1Functions();
            InsertGroup2Functions();
            //...
        }
        private void InsertGroup2Functions()
        {
            myDictionary.Add(1, group2.AnAction2);
            myDictionary.Add(2, group2.AnotherAction2);
        }
        private void InsertGroup1Functions()
        {
            myDictionary.Add(3, group1.AnAction1);
            myDictionary.Add(4, group1.AnotherAction1);
        }
        public void DoStuff()
        {
            int t = 3; //Get it from wherever
            //instead of switch
            myDictionary[t](arg1, arg2);
        }
    }
