    var index = i;                    
    App.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, (Action)(() => 
                   {
                       vm.SelectedObjectsChanged(index);
                   }));
