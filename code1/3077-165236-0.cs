    void WireUpBrowserEvents()
    {
        HtmlElement table = this._browser.Document.GetElementById( "UnitFormsTable" );
        if ( table != null )
        {
            HtmlElementCollection thead = table.GetElementsByTagName( "thead" );
            if ( ( thead != null ) && ( thead.Count == 1 ) )
            {
                HtmlElementCollection links = thead[0].GetElementsByTagName( "a" );
                if ( ( links != null ) && ( links.Count > 0 ) )
                {
                    foreach ( HtmlElement a in links )
                    {
                        a.Click += new HtmlElementEventHandler( XslSort_Click );
                    }
                }
            }
        }
    }
    void XslSort_Click( object sender, HtmlElementEventArgs e )
    {
        e.ReturnValue = false;
        if ( this._xslSortWorker.IsBusy ) return;
        if ( sender is HtmlElement )
        {
            HtmlElement a = sender as HtmlElement;
            this._browser.Hide();
            this._browserMessage.Visible = true;
            this._browserMessage.Refresh();
            this._xslSortWorker.RunWorkerAsync( a.Id );
        }
    }
