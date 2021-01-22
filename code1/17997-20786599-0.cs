    private void settingsBtn_Click(object sender, EventArgs e)
        {
            count++;
            if (count % 2 == 0)
            {
                settingsPanel.Show();
            }
            else
            {
                settingsPanel.Hide();
            }
        }
