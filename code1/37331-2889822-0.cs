    // The following is in C#
    public class fqueue
    {
      // The following code implements a circular queue of objects
      //private data:
        private bool empty;
        private bool full;
        private int begin, end;
        private object[] x;
      //public data:
        public fqueue()
        {
            empty = !(full = false);
            begin = end = 0xA2;
            x = new object[256];
            return;
        }
        public fqueue(int size)
        {
            if (1 > size) throw new Exception("fqueue: Size cannot be zero or negative");
            empty = !(full = false);
            begin = end = 0xA2;
            x = new object[size];
            return;
        }
        public object write
        {
            set
            {
                if(full) throw new Exception("Write error: Queue is full");
                end = empty ? end : (end + 1) % x.Length;
                full = ((end + 1) % x.Length) == begin;
                empty = false;
                x[end] = value;
            }
        }
        public object read
        {
            get
            {
                if(empty) throw new Exception("Read error: Queue is empty");
                full = false;
                object ret = x[begin];
                begin = (empty=end==begin) ?
                    begin :
                    (begin + 1) % x.Length;
                return ret;
            }
        }
        public int maxSize
        {
            get
            {
                return x.Length;
            }
        }
        public int queueSize
        {
            get
            {
                return end - begin + (empty ? 0 : 1 + ((end < begin) ? x.Length : 0));
            }
        }
        public bool isEmpty
        {
            get
            {
                return empty;
            }
        }
        public bool isFull
        {
            get
            {
                return full;
            }
        }
        public int start
        {
            get
            {
                return begin;
            }
        }        
        public int finish
        {
            get
            {
                return end;
            }
        }
    }
