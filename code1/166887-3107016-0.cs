    void Form_Load(object sender, EventArgs e)
    {
        try
        {
            ParseFile();
        }
        catch(Exception ex)
        {
            MessageBox.Show("The file was not valid: " + ex.Message);
        }
    }
