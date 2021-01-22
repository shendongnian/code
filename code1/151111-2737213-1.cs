        string[] list = new string[] { "1", "2", "3" };
        ObservableCollection<string> oList;
        oList = new System.Collections.ObjectModel.ObservableCollection<string>(list);
        listBox1.DataContext = oList;
        Binding binding = new Binding();
        listBox1.SetBinding(ListBox.ItemsSourceProperty, binding);
        (listBox1.ItemsSource as ObservableCollection<string>).RemoveAt(0);
