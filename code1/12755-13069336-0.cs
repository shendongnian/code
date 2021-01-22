    public class MeasureSize<T>
    {
        private readonly Func<T> _generator;
        private const int NumberOfInstances = 10000;
        private readonly T[] _memArray;
        public MeasureSize(Func<T> generator)
        {
            _generator = generator;
            _memArray = new T[NumberOfInstances];
        }
        
        public long GetByteSize()
        {
            //Make one to make sure it is jitted
            _generator();
            long oldSize = GC.GetTotalMemory(false);
            for(int i=0; i < NumberOfInstances; i++)
            {
                _memArray[i] = _generator();
            }
            long newSize = GC.GetTotalMemory(false);
            return (newSize - oldSize) / NumberOfInstances;
        }
    }
