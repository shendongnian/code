    private void Output<T>(List<T> objList)
    {
        foreach (var prop in T.GetProperties())
        {
            var column = prop.Name;
            CarDetailsGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = column,
                Binding = new Binding(column)
            });
        }
        if (objList != null && objList.Any())
        {
            foreach(var currObj in objList)
            {
                CarDetailsGrid.Items.Add(currObj);
            }
        }
    }
