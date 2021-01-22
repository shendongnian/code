     using System;
     using System.Diagnostics;
     using System.Windows;
          
     namespace diskpercent
     {
         public partial class MainWindow : Window
         {
             DispatcherTimer Timer99 = new DispatcherTimer();
             public MainWindow()
             {
                 InitializeComponent();
                 Timer99.Tick += Timer99_Tick; // don't freeze the ui
                 Timer99.Interval = new TimeSpan(0, 0, 0, 0, 1024);
                 Timer99.IsEnabled = true;
             }
             public PerformanceCounter myCounter =
                new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
             public Int32 j = 0;
             public void Timer99_Tick(System.Object sender, System.EventArgs e)
                 
             {
                     //Console.Clear();
                 j = Convert.ToInt32(myCounter.NextValue());      
                     //Console.WriteLine(j);
                 textblock1.Text = j.ToString();
             }
         }
     }
