    #include "stdafx.h"
    
    #using <mscorlib.dll>
    #using "csharpassembly.dll"
    
    using namespace System;
    using namespace Csharpassembly 
    
    __gc class Test {
    public:
       
        static void ProcessCShaperStrings()     {
            array^ stringArray = CSharpClass::GetStrings();
            Console::WriteLine(stringArray [0]); ...
            // etc
    
        } 
    };
    int wmain(void) { 
        Test:: ProcessCShaperStrings();    
        return 0;
    }
  
