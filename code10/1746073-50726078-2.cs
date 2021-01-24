        namespace WPF_Test
        {
            /// <summary>
            /// Interaction logic for App.xaml
            /// </summary>
            public partial class App : Application
            {
                void app_Startup(object sender, StartupEventArgs e)
                {
                    if (e.Args != null && e.Args.Length > 0)
                    {
                        MessageBox.Show(e.Args[0]);
                    }
                    else
                    {
                        MessageBox.Show("e.Args is null");
                    }
                }
            }
        }
