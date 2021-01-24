    int temp;
    if (int.TryParse(label16.Text, out temp))
    {
        label17.Text = (comboBox1.SelectedIndex * Convert.ToInt16(label16.Text)).ToString();
    }
    else { MessageBox.Show("Not a valid number);}
