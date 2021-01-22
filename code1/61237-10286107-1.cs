    // This is a valid C, C++ and C# file :)
    #if __LINE__
    #define public
    #else
    namespace MyCSharpNamespace{
    #endif
     
        public enum MyConstant { MaxStr = 256 };
        public enum MyEnum1{ MyEnum1_A, MyEnum1_B };
        public enum MyEnum2{ MyEnum2_A, MyEnum2_B };
    
    #if __LINE__
    #undef public
    #else
    }
    #endif
