    // parts identified by their offset within the file
    class MainApp{
        struct BlockBounds{
            public int offset;
            public int length;
            public BlockBounds(int offset, int length){
                this.offset = offset;
                this.length = length;
            }
        }
        Dictionary<Type, BlockBounds> plugins = new Dictionary<Type, BlockBounds>();
        public void RegisterPlugin(Type type, int offset, int length){
            plugins[type] = new BlockBounds(offset, length);
        }
        public void ScanContent(Container c){
            foreach(KeyValuePair<Type, int> pair in plugins)
                ((IScanner)Activator.CreateInstance(pair.Key)).Scan(
                    c.GetData(pair.Value.offset, pair.Value.length);
        }
    }
