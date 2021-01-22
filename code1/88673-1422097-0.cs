    private void ExportResults_IsEnabledChanged (object sender, DependencyPropertyChangedEventArgs e)
    {
        if (some condition)
        {
            uxExportResults.IsEnabledChanged -= ExportResults_IsEnabledChanged;
            try
            {
                uxExportResults.IsEnabled = false; // this will cause another call to the event handler, eventually resulting in a stack overflow
            }
            finally
            {
                uxExportResults.IsEnabledChanged += ExportResults_IsEnabledChanged;
            }
        }
    }
