    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.IO;
    using System.Threading;
    using System.Windows.Threading;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {             
            
            public MainWindow()
            {
                InitializeComponent();            
            }
    
            void ThreadProc()
            {
                //create second window in background thread
                Window window2 = new Window2();
                window2.Show();
    
                //start WPF message loop
                DispatcherFrame frame = new DispatcherFrame();            
                Dispatcher.PushFrame(frame);
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                //start background thread
                Thread thread2;
                thread2 = new Thread(ThreadProc);
                thread2.IsBackground = true;
                thread2.SetApartmentState(ApartmentState.STA);
                thread2.Start();
            }       
    
        }    
    }
