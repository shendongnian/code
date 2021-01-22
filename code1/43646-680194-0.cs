    class BetterLinkLabel : LinkLabel
    {
      protected override bool ProcessMnemonic( char charCode )
      {
        if( base.ProcessMnemonic( charCode ) )
        {
          OnLinkClicked( new LinkLabelLinkClickedEventArgs( this ) );
          return true;
        }
        return false;
      }
    }
