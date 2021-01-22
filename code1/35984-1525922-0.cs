    public class CustomScanner : ITypeScanner
    {
        #region ITypeScanner Members
        public void Process(Type type, PluginGraph graph)
        {                                   
            graph.AddType(type);
            graph.Configure(a => a.ForRequestedType(type).CacheBy(StructureMap.Attributes.InstanceScope.Hybrid));
        }
        #endregion
    }
