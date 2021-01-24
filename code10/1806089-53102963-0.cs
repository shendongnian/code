    public static class LongOperationHelper
    {
        private static object _synchObject = new object();
        private static Dictionary<string, int> _calls = new Dictionary<string, int>();
    
        private static Action<string> DisplayLongOperationRequested;
        private static Action<string> StopLongOperationRequested;
    
        public static void Begin(string messageKey)
        {
            bool isRaiseEvent = false;
    
            lock (_synchObject)
            {
                if (_calls.ContainsKey(messageKey))
                {
                    _calls[messageKey]++;
                }
                else
                {
                    _calls.Add(messageKey, 1);
    
                    isRaiseEvent = true;
                }
            }
    
            //This code got out of the lock, therefore cannot create a deadlock
            if (isRaiseEvent)
            {
                DispatcherHelper.InvokeIfNecesary(() =>
                {
                    //Raise event for the MainViewModel to display the long operation layer
                    DisplayLongOperationRequested?.Invoke(messageKey);
                });
            }
        }
    
        public static void End(string messageKey)
        {
            bool isRaiseEvent = false;
    
            lock (_synchObject)
            {
                if (_calls.ContainsKey(messageKey))
                {
                    if (_calls[messageKey] > 1)
                    {
                        _calls[messageKey]--;
                    }
                    else
                    {
                        _calls.Remove(messageKey);
    
                        isRaiseEvent = true;
                    }
                }
                else
                {
                    throw new Exception("Cannot End long operation that has not began");
                }
            }
    
            //This code got out of the lock, therefore cannot create a deadlock
            if (isRaiseEvent)
            {
                DispatcherHelper.InvokeIfNecesary(() =>
                {
                    StopLongOperationRequested?.Invoke(messageKey);
                });
            }
        }
    }
