    public class RefList<T> 
    {
        private T[] _array = new T[16];
        public int Capacity { get => _array.Length; }
        public int Length { get; private set; }
        
        // TODO Range checks ix >= 0 && ix < Length 
        public ref T this[int ix] { get => ref _array[ix]; }
        public ref T AddEmpty()
        {
            Length++;
        	
            if (Length == _array.Length)
            {
            	// This will invalidate all the ref that
                // have been returned until now!
            	Array.Resize(ref _array, _array.Length * 2);
            }
            
            return ref _array[Length - 1];
        }
    
        public ref T Add(in T value)
        {
        	ref T el = ref AddEmpty();
            
            // Note that value is *copied* to el!
        	el = value;
            
            return ref el;
        }
    }
   
