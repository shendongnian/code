    using System;
    namespace Example
    {
        //Observer
        public class SomeFacade
        {
            public void DoSomeWork(IObserver notificationObject)
            {
                Worker worker = new Worker(notificationObject);
                worker.DoWork();
            }
        }
        public class Worker
        {
            private readonly IObserver _notificationObject;
            public Worker(IObserver notificationObject)
            {
                _notificationObject = notificationObject;
            }
            public void DoWork()
            {
                //...
                _notificationObject.Progress(100);
                _notificationObject.Done();
            }
        }
        public interface IObserver
        {
            void Done();
            void Progress(int amount);
        }
    
        //Events
        public class SomeFacadeWithEvents
        {
            public event Action Done;
            public event Action<int> Progress;
    
            private void RaiseDone()
            {
                if (Done != null) Done();
            }
            private void RaiseProgress(int amount)
            {
                if (Progress != null) Progress(amount);
            }
    
            public void DoSomeWork()
            {
                WorkerWithEvents worker = new WorkerWithEvents();
                worker.Done += RaiseDone;
                worker.Progress += RaiseProgress;
                worker.DoWork();
                //Also we neede to unsubscribe...
                worker.Done -= RaiseDone;
                worker.Progress -= RaiseProgress;
            }
        }
        public class WorkerWithEvents
        {
            public event Action Done;
            public event Action<int> Progress;
    
            public void DoWork()
            {
                //...
                Progress(100);
                Done();
            }
        }
    }
