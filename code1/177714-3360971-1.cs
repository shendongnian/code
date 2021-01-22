        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.LWin && e.KeyCode != Keys.RWin)
                MessageBox.Show("Hello " +  e.KeyData.ToString());
        }
