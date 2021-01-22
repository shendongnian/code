    public class ProxyAssemblyLoader : MarshalByRefObject {
        public Assembly GetAssembly(string path) {
            return Assembly.LoadFrom(path);
        }
    }
