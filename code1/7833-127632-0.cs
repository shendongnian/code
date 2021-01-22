    using System;
    using Microsoft.Office.Interop.InfoPath;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var app = new ApplicationClass();
                var uri = @".\form1.xml";
                var doc = app.XDocuments.Open(uri, 0);
    
                app.XDocuments.Close(doc);
            }
        }
    }
