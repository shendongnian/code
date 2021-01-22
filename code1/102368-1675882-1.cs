    public class RuntimeInfo : IRuntimeInfo
    {
        public bool IsSilverlight { get; private set; }
        public RuntimeInfo ()
        {
            // @Jeff's compiler directives - er, taking his
            // word 'SILVERLIGHT' is actually defined
            #if SILVERLIGHT
                IsSilverlight = true;
            #else
                IsSilverlight = false;
            #endif
        }
    }
