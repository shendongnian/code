    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using Microsoft.VisualBasic.ApplicationServices;
    
    namespace WindowsFormsApplication1 {
        class Program : WindowsFormsApplicationBase {
            [STAThread]
            static void Main(string[] args) {
                var prg = new Program();
                prg.EnableVisualStyles = true;
                prg.IsSingleInstance = true;
                prg.MainForm = new Form1();
                prg.Run(args);
            }
    
            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs e) {
                var main = this.MainForm as Form1;
                main.WindowState = FormWindowState.Normal;
                main.BringToFront();
                // You could do something interesting with the command line arguments:
                //foreach (var arg in e.CommandLine) {
                //    main.OpenFile(arg);
                //}
            }
        }
    }
