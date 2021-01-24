    private void comboBox1_DropdownClosed(object sender, EventArgs e)
    {
        Thread t = new Thread(updateBox);
        t.Start();
        
        
    }
    private void updateBox()
    {
        Task.Delay(10);
        Invoke(new Action(() =>
        {
            textBox1.Text = Defaults.Defaults.DefaultOutputContainer(comboBox1.Text);
        }));
        
    }
