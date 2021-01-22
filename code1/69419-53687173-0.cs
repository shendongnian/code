    void button_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
        {
            e.IsInputKey = true;
        }
    }
