    List<string> mylist = new List<string>();
            private void btnAddToList_Click(object sender, System.Windows.RoutedEventArgs e)
            {
                mylist.Add(txtList.Text);
                ListBox1.ItemsSource = null;
                ListBox1.ItemsSource = mylist;
            }
