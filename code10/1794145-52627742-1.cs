    private void Timer_Tick(object sender, EventArgs e)
    {
        if(_modbusEvents.Count > 0)
        {
            listBox1.BeginUpdate();
            while(_modbusEvents.TryTake(out var result))
            {
                 listBox1.Items.Add(result.Fc1);
                 listBox1.Items.Add(result.StartAddress1);
                 listBox1.Items.Add(result.NumOfPoints1);
            }
            listBox1.EndUpdate();
        }
    }
