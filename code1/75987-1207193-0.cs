    public static class FetchDepthCounter
    {
        private static Dictionary<Type, int> _DepthCounter;
        private static int _MaxDepth = 3;
        static FetchDepthCounter()
        {   
            _DepthCounter = new Dictionary<Type, int>();
        }
        public static void SetDepth(int depth)
        {
            _MaxDepth = depth;
        }
        public static void ResetCounter()
        {
            _DepthCounter.Clear();
        }
        public static bool IncrementCounter(Type entityType)
        {
            if(!_DepthCounter.ContainsKey(entityType))
            {
                _DepthCounter.Add(entityType, 0);
                return true;
            }
            if(_DepthCounter[entityType] < _MaxDepth)
            {
                ++_DepthCounter[entityType];
                return true;
            }
            return false;
        }
    }
