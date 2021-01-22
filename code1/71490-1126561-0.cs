       using System;
        using WatiN.Core;
        
        namespace Test
        {
          class WatiNConsoleExample
          {
            [STAThread]
            static void Main(string[] args)
            {
              // Open an new Internet Explorer Window and
              // goto the google website.
              IE ie = new IE("http://www.google.com");
         
              // Write out the HTML text of the body
              Console.WriteLine(ie.Text);
        
        
              // Close Internet Explorer and the console window immediately.
              ie.Close();
        
              Console.Readkey();
            }
          }
        } 
