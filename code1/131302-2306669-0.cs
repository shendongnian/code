    // main code file in MyApplication
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyLib;  // This will allow me to access the classes inside MyLib directly
    namespace PdfPrinter
    {
        class Program
        {
            static void Main(string[] args)
            {
                 // if we have declared the namespace at the top, we can do:
                 MyLibClass cls = new MyLibClass();
                 // or if you don't want to add the namespace at the top we have to do:
                 MyLib.MyLibClass cls = new MyLib.MyLibClass();
            }
        }
    }
