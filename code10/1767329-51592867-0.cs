    using namespace System;  
    using namespace System::Runtime::InteropServices;  
    
    #include <iostream>
    using namespace std;
      
    int main() {  
       String ^ str = gcnew String("Abcde");  
       Console::WriteLine(str);  //use .Net to print to screen.
       
       //extract c string from .Net String
       char *p = (char*)Marshal::StringToHGlobalAnsi(str).ToPointer();  
       cout<<p<<endl;  // use C++ to print to screen
       //free the extracted pointer.
       Marshal::FreeHGlobal(IntPtr(p));
    }  
