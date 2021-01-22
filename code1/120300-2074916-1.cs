        protected void lnkRemove_Click( object sender, EventArgs e  )
        {
            UpdateDataSource( true );
        UpdateLabelDataSource( true );
    
        BindListView();
        BindLabelListView();
    
        if ( lvDynamicTextboxes.Items.Count == 1 ) 
            lnkRemove.Visible = false;
    }
    
    private void BindListView()
    {
        List< string > dataSource = this.GetDataSource();
    
        this.lvDynamicTextboxes.DataSource = dataSource;
        this.lvDynamicTextboxes.DataBind();
    }
    
    private void IncrementTextboxCount()
    {
        List< string > dataSource = this.GetDataSource();
    
        dataSource.Add( string.Empty );
        this.SetDataSource( dataSource );
    }
    
    private List< string > GetDataSource()
    {
        List< string > dataSource = null;
    
        if ( ViewState[ "DataSource" ] != null )
            dataSource = ( List< string > )ViewState[ "DataSource" ];
        else
        {
            dataSource = new List< string >();
            dataSource.Add( string.Empty );
            ViewState[ "DataSource" ] = dataSource;
        }
    
        return dataSource;
    }
    
    private void UpdateDataSource( bool delete )
    {
        List< string > dataSource = new List< string >();
    
        foreach ( ListViewItem item in this.lvDynamicTextboxes.Items )
            if ( item is ListViewDataItem )
            {
                TextBox txt = (TextBox)item.FindControl( "txtStep" );
                dataSource.Add( txt.Text );
            }
    
        if ( delete )
            dataSource.RemoveRange( dataSource.Count-1, 1 );
    
        this.SetDataSource( dataSource );
    }
    
    protected void lvDynamicTextboxes_ItemDataBound( object sender, ListViewItemEventArgs e )
    {
        if ( e.Item is ListViewDataItem )
        {
            TextBox txt = (TextBox)e.Item.FindControl( "txtStep" );
            txt.Text = ( (ListViewDataItem)e.Item ).DataItem.ToString();
        }
    }
    
    private void SetDataSource( List< string > dataSource )
    {
        ViewState[ "DataSource" ] = dataSource;
    }
    
    private void BindLabelListView()
    {
        List< string > lblDataSource = this.GetLabelDataSource();
        
        //bind the listview
        this.lvDynamicLabels.DataSource = lblDataSource;
        this.lvDynamicLabels.DataBind();
    }
    
    private void IncrementLabelCount()
    {
        List< string > lblDataSource = this.GetLabelDataSource();
    
        lblDataSource.Add( "Step " + ( lblDataSource.Count + 1 ) );
    
        this.SetLabelDataSource( lblDataSource );
    }
    
    private List< string > GetLabelDataSource()
    {
        List< string > lblDataSource = null;
    
        if ( ViewState[ "lblDataSource" ] != null )
            lblDataSource = ( List< string > )ViewState[ "lblDataSource" ];
        else
        {
            lblDataSource = new List< string >();
            lblDataSource.Add( "Step 1" );
            ViewState[ "lblDataSource" ] = lblDataSource;
        }
    
        return lblDataSource;
    }
    
    private void UpdateLabelDataSource( bool delete )
    {
        List< string > lblDataSource = new List< string >();
        int count = 1;
    
        foreach ( ListViewItem item in this.lvDynamicLabels.Items )
            if ( item is ListViewDataItem )
            {
                Label lbl = (Label)item.FindControl( "lblStep" );
                lbl.Text = "Step " + count;
                lblDataSource.Add( lbl.Text );
                count++;
            }
    
        if ( delete )
            lblDataSource.RemoveRange( lblDataSource.Count-1, 1 );
    
        this.SetLabelDataSource( lblDataSource );
    }
    
    protected void lvDynamicLabels_ItemDataBound( object sender, ListViewItemEventArgs e )
    {
        if ( e.Item is ListViewDataItem )
        {
            Label lbl = (Label)e.Item.FindControl( "lblStep" );
            lbl.Text = ( (ListViewDataItem)e.Item ).DataItem.ToString();
        }
    }
    
    private void SetLabelDataSource( List< string > lblDataSource )
    {
        ViewState[ "lblDataSource" ] = lblDataSource;
    }
