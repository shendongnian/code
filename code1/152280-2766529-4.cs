    foreach( WebControl c in FindRecursive( Page, c => (c is WebControl) && 
                               ((WebControl)c).CssClass == "instructions" ) )
    {
        c.Visible = false;
    }
