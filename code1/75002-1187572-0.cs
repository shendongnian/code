    public UserControl1()
    {
        InitializeComponent();
        this.BackColor = Color.LightGreen;
    }
    
    [DefaultValue(typeof(Color), "LightGreen")]
    public override Color BackColor
    {
        get
        {
            return base.BackColor;
        }
        set
        {
            base.BackColor = value;
        }
    }
