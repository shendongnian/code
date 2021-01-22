    public class ClassCreatedBySomeThread
    {
        Dispatcher dispatcher = Dispatcher.Current; 
    
        public void SafelyCallMeFromAnyThread(Action a)
        {
           dispatcher.Invoke(a);
        }
    } 
