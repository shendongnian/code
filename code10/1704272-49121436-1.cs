    public class MainViewModel : NotifyPropertyChangeModel
        {
            public ObservableList<DataGridColumnDef> ColumnDefinitions
            {
                get => _ColumnDefinitions;
                set => SetValue(ref _ColumnDefinitions, value);
            }
            private ObservableList<DataGridColumnDef> _ColumnDefinitions;
    
            public ObservableList<DataGridRowDef> RowDefinitions
            {
                get => _RowDefinitions;
                set => SetValue(ref _RowDefinitions, value);
            }
            private ObservableList<DataGridRowDef> _RowDefinitions;
    
            public MainViewModel()
            {
                // Define initial columns
                ColumnDefinitions = new ObservableList<DataGridColumnDef>()
                {
                    new DataGridColumnDef("Column 1", typeof(string)),
                    new DataGridColumnDef("Column 2", typeof(int)),
                };
    
                // Create row models from initial column definitions
                RowDefinitions = new ObservableList<DataGridRowDef>();
                for(int i = 0; i < 100; ++i)
                {
                    RowDefinitions.Add(new DataGridRowDef(ColumnDefinitions));
                    // OR
                    //RowDefinitions.Add(new DataGridRowDef(ColumnDefinitions, new object[] { "default", 10 }));
                }
            }
        }
