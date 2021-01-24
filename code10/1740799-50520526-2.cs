    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Word;
    namespace EditWordDotSO
    {
        class Program
        {
            static void Main(string[] args)
            {
                var applicationWord = new Microsoft.Office.Interop.Word.Application();
                applicationWord.Visible = true;
    
                Document doc = null;
    
                try
                {
                    doc = applicationWord.Documents.Add(@"path\to\your\a.dotx");
                    doc.Activate();
                }
                catch (COMException ex)
                {
                    Console.Write(ex);
                    doc.Application.Quit();
                }
            }
        }
    }
