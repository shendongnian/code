    private Thing Selected;
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter != null)
        {
            Thing selectedThing = e.Parameter as Thing;
            Selected = selectedThing;
        }
    }
    private void MasterDetailsViewControl_Loaded(object sender, RoutedEventArgs e)
    {
        MasterDetailsViewControl.SelectedItem = Selected;
    }
