    private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int) e.KeyData == (int) Keys.Control + (int) Keys.Up)
            {
                MessageBox.Show("Ctrl + Up pressed...");
            }
        }
