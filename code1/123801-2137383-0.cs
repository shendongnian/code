    class MyCommand:IAPICommand
    {
        SynchronzationContext hostContext;
        public void Execute(Application app) // method from IAPICommand
        {
            hostContext = SynchronzationContext.Current;
            Thread threadTwo = new Thread(ShowFormMethod);
            threadTwo.Start();
        }
    
        public void ProcessWidget(Widget w, Application app)
        { 
            //uses an App to work some magic on C
            //app must be called from the original thread that called ExecuteCommand()
            SomeType someData = null;
            hostContext.Send(delegate { someData = app.SomeMethod(); }, null);
        }
    }
