    public sealed class Singleton {
        static Singleton instance = null;
        static readonly object padlock = new Object();
        Object o;
        Singleton(Object _o) {
            o = _o;
        }
        public static Singleton Instance(Object _o) {
            lock (padlock) {
                if (instance == null) {
                    instance = new Singleton(_o);
                }
                return instance;
            }
        }
    }
    Singleton s = Singleton.Instance(new Object());
