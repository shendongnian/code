    const int K = 10;
    private void TextBoxes_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var txt = (TextBox)sender;
        if (int.TryParse(txt.Text, out int value))
        {
            var row = tableLayoutPanel1.GetRow(txt);
            var lbl = tableLayoutPanel1.GetControlFromPosition(1, row);
            lbl.Text = $"{value * K}";
        }
    }
