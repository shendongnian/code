    public class CppWrapper
    {
        // C++ calls that will be dynamically loaded from proper architecture:
        public static readonly Func<long> MyCplusplusMethodUsableFromCsharpSpace;
        // Initialization:
        static CppWrapper()
        {
            if(Environment.Is64BitProcess)
            {
                MyCplusplusMethodUsableFromCsharpSpace = CppReferences64.MyCplusplusClass.Method;
                // Add your 64-bits entry points here...
            }
            else
            {
                MyCplusplusMethodUsableFromCsharpSpace = CppReferences32.MyCplusplusClass.Method;
                /* Initialize new 32-bits references here... */
            }
        }
        
        // Following classes trigger dynamic loading of the referenced C++ code
        private static class CppReferences64
        {
            public static readonly Func<long> MyCplusplusMethod = Cpp64.MyCplusplusMethod;
            /* Add any64-bits references here... */
        }
        private static class CppReferences32
        {
            public static readonly Func<long> MyCplusplusMethod = Cpp32.MyCplusplusMethod;
            /* Add any 32-bits references here... */
        }
    }
