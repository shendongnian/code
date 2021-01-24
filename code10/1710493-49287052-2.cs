    public class MySerializationBinder : ISerializationBinder
    {
        const string namespaceToRemove = "PROJECTNAME.Api.";
        readonly ISerializationBinder binder;
        public MySerializationBinder() : this(new Newtonsoft.Json.Serialization.DefaultSerializationBinder()) { }
        public MySerializationBinder(ISerializationBinder binder)
        {
            if (binder == null)
                throw new ArgumentNullException();
            this.binder = binder;
        }
        #region ISerializationBinder Members
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            binder.BindToName(serializedType, out assemblyName, out typeName);
            if (typeName != null && typeName.StartsWith(namespaceToRemove))
                typeName = typeName.Substring(namespaceToRemove.Length);
            assemblyName = null;
        }
        public Type BindToType(string assemblyName, string typeName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
