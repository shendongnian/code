    public class MyLocks {
        public static object OrderLock;
        static MyLocks() {
            OrderLock = new object();
        }
    }
