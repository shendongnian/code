    class BetterLinkLabel : LinkLabel
    {
      protected override bool ProcessMnemonic( char charCode )
      {
        if( base.ProcessMnemonic( charCode ) )
        {
          // TODO: pass a valid LinkLabel.Link to the event arg ctor
          OnLinkClicked( new LinkLabelLinkClickedEventArgs( null ) );
          return true;
        }
        return false;
      }
    }
