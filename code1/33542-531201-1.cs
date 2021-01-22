    public class MyQueue<T> : Queue<T> {
        public MyQueue() 
            : base() {
            // Default constructor
        }
        public MyQueue(Int32 capacity)
            : base(capacity) {
            // Default constructor
        }
        /// <summary>
        /// Removes the item at the specified index and returns a new Queue
        /// </summary>
        public MyQueue<T> RemoveAt(Int32 index) {
            MyQueue<T> retVal = new MyQueue<T>(Count - 1);
            for (Int32 i = 0; i < this.Count - 1; i++) {
                if (i != index) {
                    retVal.Enqueue(this.ElementAt(i));
                }
            }
            return retVal;
        }
    }
