    void SomeHandler(object sender, EventArgs e)
    {
        int a, b;           
        int i=0;
        while(i<5)
        {
            i += 1;
            Thread.Sleep(1000);
            Application.DoEvents(); //Yield control to message pump
            label1.Text += "a";               
        }
        MessageBox.Show("done");
    }
