    public void MessegingCenterInit()
        {
            #region Bluetooth
           
            MessagingCenter.Subscribe<string, string>("App", "Status_name", (sender, arg) =>
            {
                App.PVM.Name = $"{arg}";//using INotifyPropertyChanged and view model
                viewmodelMethod();//using only a viewmodel
             });
            #endregion
        }
