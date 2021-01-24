        private void dgcQtdPedida_KeyUp(object sender, KeyEventArgs e)
        {
        }
        private void dgcQtdPedida_LostFocus(object sender, RoutedEventArgs e)
        {
            var t = (ClickSelectTextBox)sender;
            if (string.IsNullOrWhiteSpace(t.Text))
            {
                t.Text = "0";
            }
            model obj = ((FrameworkElement)sender).DataContext as model;
            obj.ChangeQtd(long.Parse(t.Text));
            PedDataGrid.Items.Refresh();
        }
