    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
        namespace Project1
        {
        class Class2
        {
            
            [STAThread]
            static void Main()
            {
               Console.WriteLine("hello");
               Class2 t = new Class2();
               t.test();
               Console.WriteLine("second string");
            }
             
    
    
            public void test()
            {
                Thread t = new Thread(new ThreadStart(StartNewStaThrea));
                t.Start();
            }
    
    
            private void StartNewStaThrea()
            { 
                Application.Run(new Form1()); 
            }
            
        }
    }
