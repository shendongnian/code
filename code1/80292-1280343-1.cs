    using namespace System;
    
    namespace CPPLibrary {
    
      public ref class CPPClass
      {
      public:
        String^ UseDelegate( CSLibrary::CSClass::ACSharpDelegate^ dlg )
        {
          String^ dlgReturn = dlg("World");
          return String::Format("{0} !", dlgReturn);
        }
      };
    }
