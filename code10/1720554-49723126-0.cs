    private void yourControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if(e.KeyData == Keys.Tab)
        {
            // whatever
        }
        if (e.KeyData == (Keys.Tab | Keys.Shift))
        {
            // whatever
        }
    }
