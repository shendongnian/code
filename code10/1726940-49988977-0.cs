    [NLog.LayoutRenderers.LayoutRenderer("assemblyName")]
    public class AssemblyNameLayoutRenderer : NLog.LayoutRenderers.LayoutRenderer
    {
        static ConcurrentDictionary<string, string> loggerNameToAssemblyNameCache = new ConcurrentDictionary<string, string>();
        
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var fullClassName = logEvent.LoggerName;
            var assemblyName = FindAssemblyNameFromClassName(fullClassName);
            if (!string.IsNullOrEmpty(assemblyName))
                builder.Append(assemblyName);
        }
        private string FindAssemblyNameFromClassName(string fullClassName)
        {
            return loggerNameToAssemblyNameCache.GetOrAdd(fullClassName, cl =>
            {
                var klass = (
                    from a in AppDomain.CurrentDomain.GetAssemblies()
                    from t in a.GetTypes()
                    where t.FullName == fullClassName
                    select t).FirstOrDefault();
                return klass?.Assembly.GetName().Name;
            });
        }
    }
