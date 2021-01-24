    private void TransportValueEvent_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(textBox4.Text))
        {
            (sender as TextBox).Text = textBox4.Text;
        }
    }
