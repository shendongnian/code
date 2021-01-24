    public async void OnNavigatingTo(NavigationParameters parameters) {
        try {
            Models.Vehicle Current = await App.SettingsInDb.CurrentVehicle();
            Action action = () => CommonProperty = Current.NameToShow;
            Dispatcher dispatchObject = Application.Current.Dispatcher;
            if (dispatchObject == null || dispatchObject.CheckAccess()) {
                action();
            } else {
                dispatchObject.Invoke(action);
            }
        } catch (Exception e) {
            App.LogToDb.Error(e);
        }
    }
