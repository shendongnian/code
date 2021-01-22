    <List<string>> tempList = new List<List<string>> {
        new List<string> { "vince", "elizabeth", "brian", "mark" },
        new List<string> { "vince2", "elizabeth2", "brian2", "mark2" },
        new List<string> { "vince3", "elizabeth3", "brian3", "mark3" },
        new List<string> { "vince4", "elizabeth3", "brian3", "mark4" },
    };
    for(int i=0; i<tempList[0].Count; i++) {
        DataGrid_Standard.Columns.Add(new DataGridTextColumn {
                Header = i,
                DataFieldBinding = new Binding("[" + i + "]")
            });
    }
    DataGrid_Standard.ItemsSource = tempList;
