    #ifdef _M_X64
    namespace Cpp64 {
    #else
    namespace Cpp32 {
    #endif
        public ref class MyCPlusPlusClass
        {
            public: static __int64 Method(void) { return 123; }
        };
    }
