    protected void Application_Start( object sender, System.EventArgs e ) {
     EPDataFactory.CreatingPage += new EPiServer.PageEventHandler( OnCreatingPage );
    }
    
    private void OnCreatingPage( object sender, EPiServer.PageEventArgs e ) {
      e.TargetLink <-- should be the parent
    }
