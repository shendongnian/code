    void Form1_Load( object sender, EventArgs e ) {
    	const int COUNT = 10;
    
    	TableLayoutPanel pnlContent = new TableLayoutPanel();
    	pnlContent.Dock = DockStyle.Fill;
    	pnlContent.AutoScroll = true;
    	pnlContent.AutoScrollMargin = new Size( 1, 1 );
    	pnlContent.AutoScrollMinSize = new Size( 1, 1 );
    	pnlContent.RowCount = COUNT;
    	pnlContent.ColumnCount = 3;
    	for ( int i = 0; i < pnlContent.ColumnCount; i++ ) {
    		pnlContent.ColumnStyles.Add( new ColumnStyle() );
    	}
    	pnlContent.ColumnStyles[0].Width = 100;
    	pnlContent.ColumnStyles[1].Width = 5;
    	pnlContent.ColumnStyles[2].SizeType = SizeType.Percent;
    	pnlContent.ColumnStyles[2].Width = 100;
    
    	this.Controls.Add( pnlContent );
    
    	for ( int i = 0; i < COUNT; i++ ) {
    		pnlContent.RowStyles.Add( new RowStyle( SizeType.Absolute, 20 ) );
    
    		Label lblTitle = new Label();
    		lblTitle.Text = string.Format( "Row {0}:", i + 1 );
    		lblTitle.TabIndex = (i * 2);
    		lblTitle.Margin = new Padding( 0 );
    		lblTitle.Dock = DockStyle.Fill;
    		pnlContent.Controls.Add( lblTitle, 0, i );
    
    		TextBox txtValue = new TextBox();
    		txtValue.TabIndex = (i * 2) + 1;
    		txtValue.Margin = new Padding( 0 );
    		txtValue.Dock = DockStyle.Fill;
    		txtValue.KeyDown += new KeyEventHandler( txtValue_KeyDown );
    		pnlContent.Controls.Add( txtValue, 2, i );
    	}
    }
    
    void txtValue_KeyDown( object sender, KeyEventArgs e ) {
    	if ( e.KeyCode == Keys.Enter ) {
    		SendKeys.Send( "{TAB}" );
    	}
    }
