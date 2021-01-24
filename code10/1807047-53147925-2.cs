    private DataGridViewColumnHeadersHeightSizeMode m_ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    public CustomDGV()
    {
    }
    protected override void OnLayout(LayoutEventArgs e)
    {
        base.OnLayout(e);
        base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; 
    }
    public new DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
    {
        get { return this.m_ColumnHeadersHeightSizeMode; }
        set
        {
            this.m_ColumnHeadersHeightSizeMode = value;
            base.ColumnHeadersHeightSizeMode = this.m_ColumnHeadersHeightSizeMode;
        }
    }
