    public Form1()
    {
        InitializeComponent();
        foreach (Control control in Controls)
        {
            control.Tag = "FromDesigner";
        }
    }
