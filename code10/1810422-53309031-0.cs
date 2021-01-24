    //XAML Layout
    <StackPanel Orientation="Horizontal" VerticalAlignment="Top" Name="ComboBoxPanel"  Grid.Row="1"  Margin="0,0,0,0"  HorizontalAlignment="Left" />
                                        
    //Function to create new box and set options
    private ComboBox CreateComboBox(string ColumnName, string selectedItem, int width)
    {
        string[] data = { "Date", "LEInt", "String" };
    
        ComboBox dgCmbCol = new ComboBox();
        dgCmbCol.ItemsSource = data;
        dgCmbCol.Name = ColumnName;
        dgCmbCol.Width = width;
        dgCmbCol.SelectedItem = selectedItem;
        dgCmbCol.SelectionChanged += DataTypeSelectionChanged;
        return dgCmbCol;
    }
    
    // This reads a JSON file and uses it's options to set the width of all the columns
    // for the DataGrid and matches the ComboBoxes to it so they all line up
    dynamic TableData = JsonConvert.DeserializeObject(Config.DataLayoutDefinition);
    ComboBoxPanel.Children.Clear(); //Since this is run on user interaction, clear old contents.
                
    for (int i = 0; i <  DataGridView.Columns.Count; i++)
    {
        int width = TableData.data[i].ColumnWidth;
        if (TableData.data[i].DataType == "String")
        {
            width = 125;
        }
        else if (TableData.data[i].DataType == "Date")
        {
            width = 150;
        }
        else if (TableData.data[i].DataType == "LEInt")
        {
            width = 80;
        }
        else
        {
            width = 100;
        }
    ComboBoxPanel.Children.Add(CreateComboBox(TableData.data[i].Column.ToString(), TableData.data[i].DataType.ToString(), width));
        DataGridView.Columns[i].Width = width;
    
    }
