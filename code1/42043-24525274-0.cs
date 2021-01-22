     new Thread(() => 
     {
         while (...)
         {
             SomeLabel.Dispatcher.BeginInvoke((Action)(() => SomeLabel.Text = ...));
         }
     }).Start();
