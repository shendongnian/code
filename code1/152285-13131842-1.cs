        // utility method to recursively find controls matching a predicate
        IEnumerable<Control> FindRecursive( Control c, Func<Control,bool> predicate )
        {
            if( predicate( c ) )
                yield return c;
            foreach( var child in c.Controls )
                foreach( var match in FindRecursive( (Control)child, predicate ) )
                   yield return match;
        }
        foreach (Control c in FindRecursive(Page, c => (c is HtmlGenericControl) &&
             ((HtmlGenericControl)c).Attributes["ishidden"] == "1"))
        {
             c.Visible = false;
        }
