    public class NvApplicationContext : ApplicationContext {
        public static readonly NvApplicationContext Current = new NvApplicationContext();
        public T CreateForm<T>() where T : Form, new() {
            var ret = new T();
            // register event handlers here
            return ret;
        }
    }
