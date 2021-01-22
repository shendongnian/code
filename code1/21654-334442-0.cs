    Page tmpPage = new TempPage(); // temporary page
    Control tmpCtl = tmpPage.LoadControl( "~/UDynamicLogin.ascx" );
    tmpPage.Form.Controls.Add( tmpCtl );
    
    StringBuilder html = new StringBuilder();
    using ( System.IO.StringWriter swr = new System.IO.StringWriter( html ) ) {
        using ( HtmlTextWriter writer = new HtmlTextWriter( swr ) ) {
            tmpForm.RenderControl( writer );
        }
    }
