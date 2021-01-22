    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                Application.Run(new Form1());
            }
        }
    
        interface IObserver
        {
            void Refresh(List<string> DisplayList);
        }
    
        class ObserverList : List<IObserver>
        {
            public void Refresh(List<String> DisplayList)
            {
                foreach (IObserver tItem in this)
                {
                    tItem.Refresh(DisplayList);
                }
            }
    
        }
    }
