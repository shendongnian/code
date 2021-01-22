    private bool _updating = false;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (!_updating)
        {
            try
            {
                _updating = true;
                // do work ...
                textBox1.Text = ...
            }
            finally
            {
                _updating = false;
            }            
        }
    }
