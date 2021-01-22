    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Drawing;
    
    namespace ConsoleApplication9
    {
        public class Form1 : Form
        {
            private UserControl1 uc1;
    
            public Form1()
            {
                uc1 = new UserControl1();
                uc1.BeginInit();
                uc1.Location = new Point(8, 8);
    
                Controls.Add(uc1);
    
                uc1.EndInit();
            }
        }
    
        public class UserControl1 : UserControl, ISupportInitialize
        {
            public UserControl1()
            {
                Console.Out.WriteLine("Parent in constructor: " + Parent);
            }
    
            public void BeginInit()
            {
                Console.Out.WriteLine("Parent in BeginInit: " + Parent);
            }
    
            public void EndInit()
            {
                Console.Out.WriteLine("Parent in EndInit: " + Parent);
            }
        }
    
        class Program
        {
            [STAThread]
            static void Main()
            {
                Application.Run(new Form1());
            }
        }
    }
