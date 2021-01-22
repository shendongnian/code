    private void ExportResults_IsEnabledChanged (object sender, DependencyPropertyChangedEventArgs e)
    {
      if (uxExportResults.IsEnabled == true)
      {
        uxExportResults.IsEnabled = false;
      }
    }
