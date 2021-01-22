    private string oldText;
    private void txtDescrip_KeyPress(object sender, KeyPressEventArgs e)
    {
        oldText = txtDescrip.Text;
    }
    private void txtDescrip_TextChanged(object sender, EventArgs e)
    {
        Size textSize = TextRenderer.MeasureText(txtDescrip.Text, txtDescrip.Font);
        if (textSize.Width > txtDescrip.Width)//better spacing txtDescrip.Width - 4
            txtDescrip.Text = oldText;
        else
            oldText = txtDescrip.Text;
    }
