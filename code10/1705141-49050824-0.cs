            private void DataLoging_Load(object sender, EventArgs e)
        {
            try
            {
             txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
