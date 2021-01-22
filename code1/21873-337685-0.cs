    Panel CreatePanelWithDynamicControls() {
        Panel ret = new Panel();
        ret.Dock = DockStyle.Fill;
        // some logic, which initialize content of panel
    
        return ret;
    }
    
    void InitializeDynamicControls() {
        this.Controls.Clear();
        Panel pnl = this.CreatePanelWithDynamiControls();
        this.Controls.Add( pnl );
    }
    
    void Form1_Load( object sender, EventArgs e ) {
        if ( !this.DesignMode ) {
            this.InitializeDynamicControls();
        }
    }
    
    // I don't know exactly, on which situation
    // do you want reset controls
    void SomeEvent( object sender, EventArgs e ) {
        this.InitializeDynamicControls();
    }
