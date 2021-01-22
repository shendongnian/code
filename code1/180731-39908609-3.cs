    public class MySingleton {
        private static object myLock = new object();
        private static volatile MySingleton mySingleton = null;
    
        private MySingleton() {
        }
    
        public static MySingleton GetInstance() {
            if (mySingleton == null) { // 1st check
                lock (myLock) {
                    if (mySingleton == null) { // 2nd (double) check
                        mySingleton = new MySingleton();
                        // Write-release semantics are implicitly handled by marking mySingleton with
                        // 'volatile', which inserts the necessary memory barriers between the constructor call
                        // and the write to mySingleton. The barriers created by the lock are not sufficient
                        // because the object is made visible before the lock is released.
                    }
                }
            }
            // The barriers created by the lock are not sufficient because not all threads will
            // acquire the lock. A fence for read-acquire semantics is needed between the test of mySingleton
            // (above) and the use of its contents.This fence is automatically inserted because mySingleton is
            // marked as 'volatile'.
            return mySingleton;
        }
    }
