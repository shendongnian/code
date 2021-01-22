    public class MyComponent {
        private AsyncOperation _asyncOperation;
        /// Constructor of my component:
        MyComponent() {
            _asyncOperation = AsyncOperationManager.CreateOperation(null);
        }
        /// <summary>
        /// Raises an event, ensuring the correct context
        /// </summary>
        /// <param name="eventDelegate"></param>
        /// <param name="args"></param>
        protected void RaiseEvent(Delegate eventDelegate, object[] args)
        {
            if (eventDelegate != null)
            {
                _asyncOperation.Post(new System.Threading.SendOrPostCallback(
                    delegate(object argobj)
                    {
                        eventDelegate.DynamicInvoke(argobj as object[]);
                    }), args);
            }
        }
    }
