    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    namespace Test
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Form form = new Form2();
                form.Closing += form_Closing;
                Application.Run(form);
            }
            private static void form_Closing(object sender, CancelEventArgs e)
            {
                MessageBox.Show("Closing");
            }
        }
    }
