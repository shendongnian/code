    using System;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        [STAThread]
        static void Main(string[] args)
        {
          Application.Run(new MessageWindow());
          
          Console.ReadKey();
        }
      }
    
      class MessageWindow : Form
      {
        public MessageWindow()
        {
          this.ShowInTaskbar = false;
          this.WindowState = FormWindowState.Minimized;
        }
    
        protected override void WndProc(ref Message m)
        {
          base.WndProc(ref m);
        }
      }
    }  
