    public class GroupAction
    {
        public delegate void ActionCompletion();
        private uint _count = 0;
        private ActionCompletion _callback;
        private object _lockObject = new object();
        public GroupAction(uint count, ActionCompletion callback)
        {
            _count = count;
            _callback = callback;
        }
        public void SingleActionComplete()
        {
            lock(_lockObject)
            {
                if (_count > 0)
                {
                    _count--;
                    if (_count == 0) _callback();
                }
            }
        }
    }
