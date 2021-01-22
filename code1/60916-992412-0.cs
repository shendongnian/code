    public class CatalogBinder: System.Runtime.Serialization.SerializationBinder
    {
        public override Type BindToType (string assemblyName, string typeName) 
        { 
            // get the 'fully qualified (ie inc namespace) type name' into an array
            string[] typeInfo = typeName.Split('.');
            // because the last item is the class name, which we're going to 
            // 'look for' in *this* namespace/assembly
            string className=typeInfo[typeInfo.Length -1];
            if (className.Equals("Catalog"))
            {
                return typeof (Catalog);
            }
            else if (className.Equals("Word"))
            {
                return typeof (Word);
            }
            if (className.Equals("File"))
            {
                return typeof (File);
            }
            else
            {    // pass back exactly what was passed in!
                return Type.GetType(string.Format( "{0}, {1}", typeName, 
                                    assemblyName));
            }
        } 
    }
