    using System;
    using System.Linq;
    using System.Reflection;
    using System.Diagnostics;
    using System.Security.Principal;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        internal static class Program
        {
            private class Form1 : Form
            {
                internal Form1()
                {
                    var button = new Button{ Dock = DockStyle.Fill };
                    button.Click += (sender, args) => RunAsAdmin();
                    Controls.Add(button);
    
                    ElevatedAction();
                }
            }
    
            [STAThread]
            internal static void Main(string[] arguments)
            {
                if (arguments?.Contains("/run_elevated_action") == true)
                {
                    ElevatedAction();
                    return;
                }
    
                Application.Run(new Form1());
            }
    
            private static void RunAsAdmin()
            {
                var path = Assembly.GetExecutingAssembly().Location;
                using (var process = Process.Start(new ProcessStartInfo(path, "/run_elevated_action")
                {
                    Verb = "runas"
                }))
                {
                    process?.WaitForExit();
                }
            }
    
            private static void ElevatedAction()
            {
                MessageBox.Show($@"IsElevated: {IsElevated()}");
            }
    
            private static bool IsElevated()
            {
                using (var identity = WindowsIdentity.GetCurrent())
                {
                    var principal = new WindowsPrincipal(identity);
    
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
            }
    
        }
    }
