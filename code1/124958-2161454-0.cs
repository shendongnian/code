    protected override void OnClosing(CancelEventArgs e) {
      if ( false == this.CanClose ) { // you should check, if form can be closed - in some cases you want the close application, right ;)?
        e.Cancel = true; // for event listeners know, the close is canceled
      }
      base.OnClosing(e);
      if ( false == this.CanClose ) {
        e.Cancel = true; // if some event listener change the "Cancel" property
        this.Minimize();
      }
    }
