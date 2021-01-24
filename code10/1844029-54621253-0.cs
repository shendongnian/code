    public IEnumerabe<string> SampleData
    {
        get
        {
            // Return values based on the selection.
            if (SelectedData == "FirstValueICareAbout") // SelectedData assumes you have investigated how to bind to the SelectedItem of a ComboBox.
            {
                return new[]
                {
                    "FirstValue",
                    "SecondValue"
                };    
            }
            return Enumerable.Empty<string>();
        }
    }
    private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Notify the UI that SampleData has changed using INotifyPropertyChanged implementation.
        RaiseNotifyPropertyChanged(nameof(SampleData));
    }
