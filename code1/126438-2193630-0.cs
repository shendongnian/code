    private void myButton_Click(object sender, EventArgs e)
        {
            if (tbxLastName.Text == "")
            {
                myPanel.BackColor = Color.Red;
            }
            else
            {
                myPanel.BackColor = Color.Transparent;
            }
        }
