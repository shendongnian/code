    public class NetCoreSerializationBinder : DefaultSerializationBinder
    {
        private static readonly Regex regex = new Regex(
            @"System\.Private\.CoreLib(, Version=[\d\.]+)?(, Culture=[\w-]+)(, PublicKeyToken=[\w\d]+)?");
    
        private static readonly ConcurrentDictionary<Type, (string assembly, string type)> cache =
            new ConcurrentDictionary<Type, (string, string)>();
    
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            base.BindToName(serializedType, out assemblyName, out typeName);
    
            if (cache.TryGetValue(serializedType, out var name))
            {
                assemblyName = name.assembly;
                typeName = name.type;
            }
            else
            {
                if (assemblyName.AsSpan().Contains("System.Private.CoreLib".AsSpan(), StringComparison.OrdinalIgnoreCase))
                    assemblyName = regex.Replace(assemblyName, "mscorlib");
    
                if (typeName.AsSpan().Contains("System.Private.CoreLib".AsSpan(), StringComparison.OrdinalIgnoreCase))
                    typeName = regex.Replace(typeName, "mscorlib");
    
                cache.TryAdd(serializedType, (assemblyName, typeName));
            }
        }
    }
