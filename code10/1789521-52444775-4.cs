    public class ActionMonitor
    {
        public ActionMonitor()
        {
    
        }
    
        private object _lockObj = new object();
    
        public void OnActionEnded()
        {
            lock (_lockObj)
            {
                IsInAction = false;
    
                var tmpTriggers = _triggers;
                _triggers = new HashSet<Action>();
                foreach (var trigger in tmpTriggers)
                    trigger();
    
                //have to decide what to do if _triggers isn't empty here, we could use a while loop till its empty
                //so for example
    
                while (true)
                {    
                    var tmpTriggers = _triggers;
                    _triggers = new HashSet<Action>();
                    if (tmpTriggers.Count == 0)
                        break;
    
                    foreach (var trigger in tmpTriggers)
                        trigger();
                }
            }
        }
    
        public void OnActionStarted()
        {
            lock (_lockObj) //fix the error @EricLippert talked about in comments
                IsInAction = true;
        }
    
        private ISet<Action> _triggers = new HashSet<Action>();
        public void ExecuteAfterAction(Action action)
        {
            lock (_lockObj)
            {
                if (IsInAction)
                    _triggers.Add(action);
                else
                    action();
            }
        }
    
        public bool IsInAction
        {
           get;private set;
        }
    }
