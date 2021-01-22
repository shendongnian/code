    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            await Task.Run(Test);
        }
        catch (Exception)
        { 
    
        }
    }
