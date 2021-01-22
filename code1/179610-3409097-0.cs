        public class ResxResourceManager : System.Resources.ResourceManager {
            public ResxResourceManager(string baseName, string resourceDir) {
                Type[] paramTypes = new Type[] { typeof(string), typeof(string), typeof(Type) };
                object[] paramValues = new object[] { baseName, resourceDir, typeof(ResXResourceSet) }; 
        
                Type baseType = GetType().BaseType;
        
                ConstructorInfo ci = baseType.GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null, paramTypes, null);
        
                ci.Invoke(this, paramValues);
            }
    
        protected override string GetResourceFileName(CultureInfo culture) {
            string resourceFileName = base.GetResourceFileName(culture);
            return resourceFileName.Replace(".resources", ".resx");
        }
    }
