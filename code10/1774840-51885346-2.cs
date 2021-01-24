    public Form1()
    {
        InitializeComponent();
        TabControl tc1 = new TabControl()
        {
            Dock = DockStyle.Fill
        };
        for (int i = 0; i < 5; i++)
        {
            tc1.TabPages.Add(i.ToString());
        }
        foreach (TabPage tp in tc1.TabPages)
        {
            TabControl tc2 = new TabControl
            {
                Dock = DockStyle.Fill
            };
            for (int i = 0; i < 5; i++)
            {
                tc2.TabPages.Add(tp.Text + "." + i.ToString());
            }
            tp.Controls.Add(tc2);
            foreach (TabPage tp2 in tc2.TabPages)
            {
                TabControl tc3 = new TabControl
                {
                   Dock = DockStyle.Fill
                };
                for (int i = 0; i < 5; i++)
                {
                    tc3.TabPages.Add(tp2.Text + "." + i.ToString());
                }
                tp2.Controls.Add(tc3);
            }
        }
        this.Controls.Add(tc1);
    }
