    protected async Task test()
        {
            label1.Text = "";
            for (int i = 0; i < 10; i++)
            {
                label1.Text += i;
                await Task.Delay(500);
            }
        }
