    public class ClassCreatedBySomeThread
    {
        Dispatcher dispatcher = Dispatcher.CurrentDispatcher; 
    
        public void SafelyCallMeFromAnyThread(Action a)
        {
           dispatcher.Invoke(a);
        }
    } 
