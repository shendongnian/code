    private void tbxMod_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnMod.PerformClick();
            e.SuppressKeyPress = true;
        }
    }
