    private void getSelectedItem(object sender, MouseButtonEventArgs e)
    {
        Book book = (Book)listView1.SelectedItems[0];
        System.Windows.MessageBox.Show(book.ISBN);
    }
