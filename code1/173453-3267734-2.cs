     private void MyEventHandler(object sender, MouseButtonEventArgs e)
        {
            ListViewItem MyListViewItem = (ListViewItem)sender;
            MyClass MyObject = (MyClass)Item.Content;
            e.Handled = true;
        }
