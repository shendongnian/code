    var tree = new Gtk.TreeView ();
    this.Add( tree );
     
    // Create a column for the file path
    Gtk.TreeViewColumn pathColumn = new Gtk.TreeViewColumn ();
    pathColumn.Title = "Path";
    tree.appendColumn( pathColumn );
    
    // Create an appropriate model
    var pathListStore = new Gtk.ListStore( typeof( string ) );
    tree.Model = pathListStore;
    
    // Add the data
    foreach(string path in paths) {
        tree.AppendValues( path );
    }
    
    this.ShowAll();
