    public class MyQueue<T> : Queue<T> {
        /// <summary>
        /// Removes the item at the specified index and returns a new Queue
        /// </summary>
        public Queue<T> RemoveAt(Int32 index) {
            Queue<T> retVal = new Queue<T>(Count - 1);
            for (Int32 i = 0; i < this.Count - 1; i++) {
                if (i != index) {
                    retVal.Enqueue(this.ElementAt(i));
                }
            }
            return retVal;
        }
    }
