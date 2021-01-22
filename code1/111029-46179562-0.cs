    namespace Test_Library
    {
        /// <summary>
        /// I should be documented.
        /// </summary>
        public class ExplicitPublicClass
        {
            public int Field;
        }
    
        /// <summary>
        /// I should NOT be documented.
        /// </summary>
        class ImplicitInternalClass
        {
            public int Field;
        }
    
        /// <summary>
        /// I should NOT be documented.
        /// </summary>
        internal class ExplicitInternalClass
        {
            public int Field;
        }
    
        /// <summary>
        /// I should be documented.
        /// </summary>
        public struct ExplicitPublicStruct
        {
            public int Field;
        }
    
        /// <summary>
        /// I should NOT be documented.
        /// </summary>
        struct ImplicitInternalStruct
        {
            public int Field;
        }
    
        /// <summary>
        /// I should NOT be documented.
        /// </summary>
        internal struct ExplicitInternalStruct
        {
            public int Field;
        }
    }
