    public class DataGridHelper : DependencyObject
    {
        public static readonly DependencyProperty SyncedColumnWidthsProperty =
            DependencyProperty.RegisterAttached(
              "SyncedColumnWidths",
              typeof(Boolean),
              typeof(DataGridHelper),
              new FrameworkPropertyMetadata(false,
                  FrameworkPropertyMetadataOptions.AffectsRender,
                  new PropertyChangedCallback(OnSyncColumnsChanged)
              ));
        private static void OnSyncColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataGrid dataGrid)
            {
                dataGrid.LoadingRow += SyncColumnWidths;
            }
        }
        private static void SyncColumnWidths(object sender, DataGridRowEventArgs e)
        {
            var dataGrid = (DataGrid)sender;
            foreach (DataGridColumn c in dataGrid.Columns)
                c.Width = 0;
            e.Row.UpdateLayout();
            foreach (DataGridColumn c in dataGrid.Columns)
                c.Width = DataGridLength.Auto;
        }
        public static void SetSyncedColumnWidths(UIElement element, Boolean value)
        {
            element.SetValue(SyncedColumnWidthsProperty, value);
        }
    }
	
