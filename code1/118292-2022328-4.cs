        private SynchronizationContext _currentcontext
        
        /// Constructor of my component:
        MyComponent() {
            _currentcontext = WindowsFormsSynchronizationContext.Current;
           //...or...?
            _currentcontext = SynchronizationContext.Current;
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
                if (_currentcontext != null)
                    _currentcontext.Post(new System.Threading.SendOrPostCallback(
                        delegate(object a)
                        {
                            eventDelegate.DynamicInvoke(a as object[]);
                        }), args);
                else
                    eventDelegate.DynamicInvoke(args);
            }
        }
