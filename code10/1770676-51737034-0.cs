    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
    () =>
    {
       SelectedPerson = ComboBoxList.FirstOrDefault(x => x.IsChecked);
    });
