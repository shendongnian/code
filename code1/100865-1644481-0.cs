    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (Control ctrl in this.Controls)
        {
            if (ctrl is Button)
            {
                Button btn = (Button)ctrl;
                btn.Click += ButtonClick;
            }
        }
    
    }
    
    private void ButtonClick(object sender, EventArgs e)
    {
        foreach (Control ctrl in this.Controls)
        {
            if (ctrl is Button)
            {
                Button btn = (Button)ctrl;
                if (btn != (Button)sender)
                {
                    btn.Enabled = false;
                }
            }
        }
    }
