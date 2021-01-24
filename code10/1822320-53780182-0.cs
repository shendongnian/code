    double[] row1 = new double[4] { 1, 2, 3, 4 };
    double[] row2 = new double[4] { 5, 6, 7, 8 };
    double[] row3 = new double[4] { 1, 3, 2, 1 };
    List<double[]> sourceCollection = new List<double[]> { row1, row2, row3 };
    dataGrid.ItemsSource = sourceCollection;
    for (int i = 0; i<sourceCollection[0].Length; ++i)
        dataGrid.Columns.Add(new DataGridTextColumn { Binding = new Binding("[" + i.ToString() + "]") });
