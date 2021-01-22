    using System;
    using System.Threading;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Form formA = new Form { Text = "FormA" };
            formA.Click += delegate {
                Form formB = new Form { Text = "FormB" };
                formB.Click += delegate {
                    Thread thread = new Thread(() =>
                    {
                        Form formC = new Form { Text = "FormC" };
                        formC.Click += delegate
                        {
                            Form formD = new Form { Text = "FormD (modal)" };
                            formD.ShowDialog(formC);
                        };
                        formC.ShowDialog(); // no owner! cross-thread;
                          // use ShowDialog so thread doesn't exit
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                };
                formB.Show(formA);
            };
            Application.Run(formA);
        }
    }
