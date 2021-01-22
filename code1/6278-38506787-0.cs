    public class MyMain()
        public void MyMethod() {
            AnotherClass.TheEventHandler += DoSomeThing;
        }
    
        private void DoSomething(object sender, EventArgs e) {
            Debug.WriteLine("I did something");
            AnotherClass.ClearAllDelegatesOfTheEventHandler();
        }
    
    }
    public static class AnotherClass {
    
        public static event EventHandler TheEventHandler;
        public static void ClearAllDelegatesOfTheEventHandler() {
            foreach (Delegate d in TheEventHandler.GetInvocationList())
            {
                TheEventHandler -= (EventHandler)d;
            }
        }
    }
 
