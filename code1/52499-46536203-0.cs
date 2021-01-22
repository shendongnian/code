        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                MessageBox.Show("You Press Enter");
            }
        }
