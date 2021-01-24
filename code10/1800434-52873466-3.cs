        public void Select_Tab1_Button(object sender, RoutedEventArgs e)
        {
            tab_control.SelectedIndex = 0;
            dg_address.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                dg_address.Focus();
            }
            ));
            if (dg_address.SelectedIndex > -1)
            {
                dg_address.ScrollIntoView(dg_address.Items[dg_address.SelectedIndex]);
                DataGridRow row = (DataGridRow)dg_address.ItemContainerGenerator.ContainerFromIndex(dg_address.SelectedIndex);
                row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
