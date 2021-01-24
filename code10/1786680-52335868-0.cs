    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
     new Action(() =>
     {
     IsProcessing= true;
     })
     );
