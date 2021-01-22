    // parts identified by name, block length stored within content (as in diagram above)
    class MainApp{
        Dictionary<string, Type> plugins = new Dictionary<string, Type>();
        public void RegisterPlugin(Type type, string partID){
            plugins[partID] = type;
        }
        public void ScanContent(Container c){
            foreach(IPart part in c.GetParts()){
                Type type;
                if(plugins.TryGetValue(part.ID, out type))
                    ((IScanner)Activator.CreateInstance(type)).Scan(part.Data);
            }
        }
    }
