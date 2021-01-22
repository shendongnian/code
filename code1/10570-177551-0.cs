    public interface ILoopIterator
    {
        void Do(Action action);
        void Do(Action<int> action);
    }
    
    private class LoopIterator : ILoopIterator
    {
        private readonly int _start, _end;
    
        public LoopIterator(int count)
        {
            _start = 0;
            _end = count - 1;
        }
    
        public LoopIterator(int start, int end)
        {
            _start = start;
            _end = end;
        }  
    
        public void Do(Action action)
        {
            for (int i = _start; i <= _end; i++)
            {
                action();
            }
        }
    
        public void Do(Action<int> action)
        {
            for (int i = _start; i <= _end; i++)
            {
                action(i);
            }
        }
    }
    
    public static ILoopIterator Times(this int count)
    {
        return new LoopIterator(count);
    }
