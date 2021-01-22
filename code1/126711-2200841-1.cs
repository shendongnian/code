    using System;
    using System.Threading;
    using System.Windows;
    namespace WpfApplication1
    {
      public partial class Window1 : Window
      {
          public Window1()
          {
              InitializeComponent();
              Thread t = new Thread(DoSomeLongTask);
              t.Start();
              // switch this with the DoSomeLongTask, so the long task is
              // on the new thread and the UI thread is free.
              ShowLoadingWindow();
              keepLooping = false;
        }
      }
    }
