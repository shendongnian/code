    public class Synchronizer {
        private Dictionary<int, object> locks;
        private object myLock;
        public Synchronizer() {
            locks = new Dictionary<int, object>();
            myLock = new object();
        }
        public object this[int index] {
            get {
                lock (myLock) {
                    object result;
                    if (locks.TryGetValue(index, out result))
                        return result;
                    result = new object();
                    locks[index] = result;
                    return result;
                }
            }
        }
    }
