    using Prism.Mvvm;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Timers;
    using System.Windows;
    
    namespace ArrayBinding
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
          DataContext = new Settings();
        }
      }
    
      class Settings: BindableBase
      {
        public ObservableCollection<ushort> Test2 { get; set; }
    
        private Timer oTimer = new Timer();
        public Settings()
        {
          Test2 = new ObservableCollection<ushort>();
          Test2.Add(666);
          Test2.Add(111);
    
          oTimer.Interval = 1000;
          oTimer.Elapsed += OnTimedEvent;
          oTimer.AutoReset = true;
          oTimer.Enabled = true;
          oTimer.Start();
    
        }
    
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
          Task.Run(async () =>
          {
            while (true)
            {
              await Task.Delay(500);
              Test2[1] += (ushort)2;
            }
          });
        }
      }
    }
