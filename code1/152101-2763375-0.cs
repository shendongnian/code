    private void button1_Click(object sender, EventArgs e)
    {
        var control = sender as Control;
        if(control == null)
            return;
        if (1 == tableLayoutPanel1.GetColumnSpan(control))
        {
            tableLayoutPanel1.SetColumnSpan(control, 2);
        }
        else
        {
            tableLayoutPanel1.SetColumnSpan(control, 1);
        }
    }
