    public class CustomScanner : ITypeScanner
    {
        #region ITypeScanner Members
        public void Process(Type type, PluginGraph graph)
        {                                   
            graph.AddType(type);
            var family = graph.FindFamily(type);
            family.AddType(type);
            family.SetScopeTo(InstanceScope.Hybrid);
        }
        #endregion
    }
