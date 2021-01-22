    #if __LINE__
    #define public
    #else
    namespace MyNamespace
    {
    #endif
    
        public enum MyEnum { MyEnumValue1, MyEnumValue2 };
        public enum MyEnum2 { MyEnum2Value1, MyEnum2Value2 };
        public enum MyEnum3 { MyEnum3Value1, MyEnum3Value2 };
    
    #if __LINE__
    #undef public
    #else
    }
    #endif
