    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            private volatile bool _waitForDispatcher = false;
            public MainWindow()
            {
                InitializeComponent();
                // we use this hook to detect when the dispatcher queue gets empty
                // so we can better adjust our throttling to add the controls to the panel
                this.Dispatcher.Hooks.DispatcherInactive += (object s1, EventArgs e1) =>
                {
                    this._waitForDispatcher = false;
                };
            }
            private async void Button1_Click(object sender, RoutedEventArgs e)
            {
                // doesn't have to be awaited if that's all this click handler does
                // but if this function needs to do other things to the UI after this task completes 
                // then you definitely must await this task.
                await Task.Run(() =>
                {
                    _waitForDispatcher = true;
                    
                    for (int i = 0; i< 10000; i++)
                    {
                        this.Dispatcher.Invoke(() => {
                            // add the control.
                            TextBox tb = new TextBox() { Text = "Text box " + i, Width = 100, Height = 22, Margin = new Thickness(0, 0, 0, 10) };
                            this.panel.Children.Add(tb);
                            this.lbl_Status.Content = "Added item " + i; // will provide a good indicator on the screen for UI freeze, especially as you resize the app
                        });
                        // throttle: for every 50 controls that we add, we wait for the dispatcher queue to clear.
                        // but limit that to 50 ms so floods of mouse events don't take over and prevent the controls from loading
                        if ((i % 50) == 0)
                        {
                            int j = 0;
                            while (_waitForDispatcher && j++ < 12) // limit to 50 ms to make sure we don't let busy mouse events block it all.
                            {
                                Thread.Sleep(5); // tweak this. Gives time for the dispatcher queue to flush
                            }
                            Console.WriteLine("Waited " + (j * 5) + " ms for dispatcher");
                            _waitForDispatcher = true;
                        }
                    }
                });
            }
        }
    }
