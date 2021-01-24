    async void SomeHandler(object sender, EventArgs e)
    {
        int a, b;           
        int i=0;
        while(i<5)
        {
            i += 1;
            await Task.Delay(1000);  //The await keyword yields control to the caller
            label1.Text += "a";               
        }
        MessageBox.Show("done");
    }
