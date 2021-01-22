     GridViewColumn column = ...
     ((System.ComponentModel.INotifyPropertyChanged)column).PropertyChanged += (sender, e) =>
     {
         if (e.PropertyName == "ActualWidth")
         {
             //do something here...
         }
     };
