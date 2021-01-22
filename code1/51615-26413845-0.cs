    using System;
    namespace test{
    class MyTestApp{
        //The Event Handler declaration
        public delegate void EventAction();
        //The Event Action Collection 
        //Equivalent to 
        //  public List<EventAction> EventActions=new List<EventAction>();
        //        
        public event EventAction EventActions;
        //An Action
        public void Hello(){
            Console.WriteLine("Hello World of events!");
        }
        //Another Action
        public void Goodbye(){
            Console.WriteLine("Goodbye Cruel World of events!");
        }
        public static void Main(){
            MyTestApp TestApp = new MyTestApp();
            //Add actions to the collection
            TestApp.EventActions += TestApp.Hello;
            TestApp.EventActions += TestApp.Goodbye;
            //Invoke all event actions
            if (TestApp.EventActions!= null){
                //this peculiar syntax hides the invoke 
                TestApp.EventActions();
                //using the 'ActionCollection' idea:
                // foreach(EventAction action in TestApp.EventActions)
                //     action.Invoke();
            }
        }
    }   
    }
