    private void button_Click(object sender, EventArgs e)
    {
        try
        {
            ((MouseEventArgs)e).Button.ToString();
        }
        catch(Exception)
        {
            //If an exception is catch, it means the mouse was not used.
        }
    }
