    private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(startBlockPosBox.Text))
            {
              .. do stuff ..
            }
            else
            {
              .. do stuff ..
              DialogResult = true; // this line caused the problem
            }
            DialogResult = true;
        }
