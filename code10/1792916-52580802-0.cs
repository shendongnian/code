       private void StoreButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = ResultLabel.Text.ToString();
            }
            StoreLabel.Text = "Results have been stored";
        }
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            DisplayListBox.Items.Clear();
            for (int i = 0; i < results.Length; i++)
            {
                DisplayListBox.Items.Add($"{results[i].ToString()} - {i}");
            } 
        }
