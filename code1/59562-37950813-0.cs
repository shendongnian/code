    private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox box = sender as ListBox;
            if (box == null) {
                return;
            }
            MyInfo info = box.SelectedItem as MyInfo;
            if (info == null)
                return;
            /* your code here */
            }
            e.Handled = true;
        }
