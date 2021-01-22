    namespace DelegateEvent
    {
        //the following line behave as a class. It is indeed a reference type
        public delegate void MyDelegate(string inputs);
        //The following line is illegal. It can only be an instance. so it cannot be directly under namespace
        //public event MyDelegate MyEvent;
        public class MyClassA
        {
            public event MyDelegate MyEventA;
            public MyDelegate MyDelegateA;
            System.Threading.ManualResetEvent MyResetEvent = new System.Threading.ManualResetEvent(false);
            public void TryToDoSomethingOnMyDelegateA()
            {
                if (MyDelegateA != null)
                {
                    //User can assecc all the public methods.
                    MyDelegateA("I can invoke detegate in classA");         //invoke delegate
                    MyDelegateA.Invoke("I can invoke detegate in classA");  //invoke delegate
                    IAsyncResult result = MyDelegateA.BeginInvoke("I can invoke detegate in classA", MyAsyncCallback, MyResetEvent);    //Async invoke
                    //user can check the public properties and fields of delegate instance
                    System.Reflection.MethodInfo delegateAMethodInfo = MyDelegateA.Method;
                    MyDelegateA = testMethod;                   //reset reference
                    MyDelegateA = new MyDelegate(testMethod);   //reset reference
                    MyDelegateA = null;                         //reset reference
                    MyDelegateA += testMethod;                  //Add delegate
                    MyDelegateA += new MyDelegate(testMethod);  //Add delegate
                    MyDelegateA -= testMethod;                  //Remove delegate
                    MyDelegateA -= new MyDelegate(testMethod);  //Remove delegate
                }
            }
            public void TryToDoSomethingOnMyEventA()
            {
                if (MyEventA != null)
                {
                    MyEventA("I can invoke Event in classA");           //invoke Event
                    MyEventA.Invoke("I can invoke Event in classA");    //invoke Event
                    IAsyncResult result = MyEventA.BeginInvoke("I can invoke Event in classA", MyAsyncCallback, MyResetEvent);      //Async invoke
                    //user can check the public properties and fields of MyEventA
                    System.Reflection.MethodInfo delegateAMethodInfo = MyEventA.Method;
                    MyEventA = testMethod;                   //reset reference
                    MyEventA = new MyDelegate(testMethod);   //reset reference
                    MyEventA = null;                         //reset reference
                    MyEventA += testMethod;                  //Add delegate
                    MyEventA += new MyDelegate(testMethod);  //Add delegate
                    MyEventA -= testMethod;                  //Remove delegate
                    MyEventA -= new MyDelegate(testMethod);  //Remove delegate
                }
            }
            private void MyAsyncCallback(System.IAsyncResult result)
            {
                //user may do something here
            }
            private void testMethod(string inputs)
            {
                //do something
            }
        }
        public class MyClassB
        {
            public MyClassB()
            {
                classA = new MyClassA();
            }
            public MyClassA classA;
            public string ReturnTheSameString(string inputString)
            {
                return inputString;
            }
            public void TryToDoSomethingOnMyDelegateA()
            {
                if (classA.MyDelegateA != null)
                {
                    //The following two lines do the same job --> invoke the delegate instance
                    classA.MyDelegateA("I can invoke delegate which defined in class A in ClassB");
                    classA.MyDelegateA.Invoke("I can invoke delegate which defined in class A in ClassB");
                    //Async invoke is also allowed
                    //user can check the public properties and fields of delegate instance
                    System.Reflection.MethodInfo delegateAMethodInfo = classA.MyDelegateA.Method;
                    classA.MyDelegateA = testMethod;                   //reset reference
                    classA.MyDelegateA = new MyDelegate(testMethod);   //reset reference
                    classA.MyDelegateA = null;                         //reset reference
                    classA.MyDelegateA += testMethod;                  //Add delegate
                    classA.MyDelegateA += new MyDelegate(testMethod);  //Add delegate
                    classA.MyDelegateA -= testMethod;                  //Remove delegate
                    classA.MyDelegateA -= new MyDelegate(testMethod);  //Remove delegate
                }
                
            }
            public void TryToDoSomeThingMyEventA()
            {
                //check whether classA.MyEventA is null or not is not allowed
                //Invoke classA.MyEventA is not allowed
                //Check properties and fields of classA.MyEventA is not allowed
                //reset classA.MyEventA reference is not allowed
                classA.MyEventA += testMethod;                  //Add delegate
                classA.MyEventA += new MyDelegate(testMethod);  //Add delegate
                classA.MyEventA -= testMethod;                  //Remove delegate
                classA.MyEventA -= new MyDelegate(testMethod);  //Remove delegate
            }
            private void testMethod(string inputs)
            {
                //do something here
            }
        }
    }
