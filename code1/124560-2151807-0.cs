    #include "yourcoollibrary.h"
    namespace DotNetLibraryNamespace
    {
        public ref class DotNetClass
        {
        public:
            DotNetClass()
            {
            }
            property System::String ^Foo
            {
                System::String ^get()
                {
                    return gcnew System::String(c.data.c_str());
                }
                void set(System::String ^str)
                {
                    marshal_context ctx;
                    c.data = ctx.marshal_as<const char *>(str);
                }
            }
        
        private:
            NativeClassInMyCoolLibrary c;
        };
    }
