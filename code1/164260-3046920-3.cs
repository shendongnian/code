            ObservableCollection<DemoModel> models = new ObservableCollection<DemoModel>();
            models.Add(new DemoModel() { Text = "Some Text #1." });
            models.Add(new DemoModel() { Text = "Some Text #2." });
            models.Add(new DemoModel() { Text = "Some Text #3." });
            models.Add(new DemoModel() { Text = "Some Text #4." });
            models.Add(new DemoModel() { Text = "Some Text #5." });
            DataGrid1.ItemsSource = models;
