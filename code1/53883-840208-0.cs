    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
        {
            if (ActiveControl.GetType() == typeof(MyCustomControl))
            {
                ((MyCustomControl)ActiveControl).Copy();
                e.Handled = true;
            }
        }
    }
