    class SortedCollection<T> where T: ICloneable
    {
        private T[] data;
        public T Top 
        { 
             get 
             { 
                 T ret = (T)data[0].Clone();
                 return ret; 
             }
        }
    
        /* rest of implementation here */
    }
