    public class Singleton: ISingleton {
        private readonly Lazy<Dictionary<string, HashSet<string>>> lazy;
        public Singleton(IReader reader) {
            this.lazy = new Lazy<Dictionary<string, HashSet<string>>>(() => reader.ReadData("config") );
        }
        public Dictionary<string, HashSet<string>> Instance { get { return lazy.Value; } }
    }
    
