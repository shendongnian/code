    public class NotSupported
    {
        public void ThrowException(string message)
        {
            throw new NotSupportedException(message);
        }
    
        public void ReflectAssembly()
        {
            MethodInfo load = 
                typeof(Assembly).GetMethod("Load", 
                                            new Type[] { typeof(string), typeof(Evidence) });
    
            if (Attribute.IsDefined(load, typeof(ObsoleteAttribute)))
            {
                // Do something
            }
        }
    
        private static bool? _isEvidenceObsolete = null;
        public static void ReflectAssemblyStatic()
        {
            Assembly asm;
            if (!_isEvidenceObsolete.HasValue)
            {
                MethodInfo load =
                   typeof(Assembly).GetMethod("Load",
                                               new Type[] { typeof(string), typeof(Evidence) });
                _isEvidenceObsolete = Attribute.IsDefined(load, typeof(ObsoleteAttribute));
            }
    
            if (_isEvidenceObsolete.Value)
            {
                //Do Stuff
            }
        }
    }
