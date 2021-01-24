    var tvTable = new Gtk.TreeView();
    this.Add( tvTable );
    var Headers = new string[] { "#", "Path" };
    var ttTable = new GtkUtil.TableTextView( this.tvTable, Headers.Count, Headers.Count );
    ttTable.Headers = Headers;
    
    foreach(string path in paths) {
        ttTable.AppendRow();
        ttTable.Set( i, 1, path );
    }
    this.ShowAll();
