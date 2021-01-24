        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                using (FormSettings settings = new FormSettings())
                {
                  settings.ShowDialog();
                }
            }
        }
