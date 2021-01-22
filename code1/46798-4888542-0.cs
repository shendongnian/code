        void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement) e.OriginalSource).DataContext as Track;
            if (item != null)
            {
                MessageBox.Show("Item's Double Click handled!");
            }
        }
