    public sealed class Singleton {
        static Singleton instance = null;
        static readonly object padlock = new Object();
        Singleton(Object o) {
        }
        public static Singleton Instance(Object o) {
            lock (padlock) {
                if (instance == null) {
                    instance = new Singleton(o);
                }
                return instance;
            }
        }
    }
    Singleton s = Singleton.Instance(new Object());
