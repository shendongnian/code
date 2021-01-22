        private void bOK_Click(object sender, RoutedEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: Tab0_OK(); break;
                case 1: Tab1_OK(); break;
            }
        }
        private void bClear_Click(object sender, RoutedEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: Tab0_Clear(); break;
                case 1: Tab1_Clear(); break;
            }
        }
