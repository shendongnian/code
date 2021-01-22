    // This is both a C++ and C# file :)
    #if __cplusplus
    #define public
    #else
    namespace MyCSharpNamespace{
    #endif
     
        public enum MyConstant { MaxStr = 256 };
        public enum MyEnum1{ MyEnum1_A, MyEnum1_B };
        public enum MyEnum2{ MyEnum2_A, MyEnum2_B };
    
    #if __cplusplus
    #undef public
    #else
    }
    #endif
