    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        var count = 0;
    
        for (var i = 0; i <= 500; i++)
        {
            count = i;
            await async (count) => 
            {
                label1.Text = i.ToString();
                await Task.Delay(100);
            };
        }
    
    }
