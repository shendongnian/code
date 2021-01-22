            private void btnArrowUp_Click(object sender, RoutedEventArgs e) {
            if(lbZones.SelectedIndex > 0) {
                lbZones.SelectedIndex--;
                lbZones.ScrollIntoView(lbZones.SelectedIndex);
            }
        }
        private void btnArrowDown_Click(object sender, RoutedEventArgs e) {
            if(lbZones.SelectedIndex < lbZones.Items.Count - 1) {
                lbZones.SelectedIndex++;
                lbZones.ScrollIntoView(lbZones.SelectedIndex);
            }
        }
