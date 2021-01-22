    public class EventSubConventionScanner : ITypeScanner
    {
        public void Process(Type type, PluginGraph graph)
        {
            Type interfaceType = type.FindInterfaceThatCloses(typeof(IConsumer<>));
            if (interfaceType != null)
            {
                graph.AddType(interfaceType, type);
            }
        }
    }
