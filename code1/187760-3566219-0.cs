    using System;
    using Gtk;
    
    public class TreeViewExample
    {
    
    public static void Main ()
    
    {
    
        Gtk.Application.Init ();
    
        new TreeViewExample ();
    
        Gtk.Application.Run ();
    
    }
    
    
    Gtk.Entry filterEntry;
    Gtk.TreeModelFilter filter;
    
    
    
    public TreeViewExample ()
    {
    
        // Create a Window
    
        Gtk.Window window = new Gtk.Window ("TreeView Example");
    
        window.SetSizeRequest (500,200);
    
        window.DeleteEvent+=delegate {Application.Quit();};
    
    
    
        // Create an Entry used to filter the tree
    
        filterEntry = new Gtk.Entry ();
    
    
    
        // Fire off an event when the text in the Entry changes
    
        filterEntry.Changed += OnFilterEntryTextChanged;
    
    
    
        // Create a nice label describing the Entry
    
        Gtk.Label filterLabel = new Gtk.Label ("Search:");
    
    
    
        // Put them both into a little box so they show up side by side
    
        Gtk.HBox filterBox = new Gtk.HBox ();
    
        filterBox.PackStart (filterLabel, false, false, 5);
    
        filterBox.PackStart (filterEntry, true, true, 5);
    
    
    
        // Create our TreeView
    
        Gtk.TreeView tv = new Gtk.TreeView ();
    
    
    
        // Create a box to hold the Entry and Tree
    
        Gtk.VBox box = new Gtk.VBox ();
    
    
    
        // Add the widgets to the box
    
        box.PackStart (filterBox, false, false, 5);
    
        box.PackStart (tv, true, true, 5);
    
    
    
        window.Add (box);
    
    
    
    
    
        //setting up columns and renderers
    
    
    
    
    
        Gtk.TreeViewColumn nameColumn = new Gtk.TreeViewColumn{Title="Name"}; 
    
        Gtk.CellRendererText nameCell = new Gtk.CellRendererText ();        
    
        nameColumn.PackStart (nameCell, true);
    
    
    
    
    
    
    
    
    
        Gtk.TreeViewColumn emailColumn = new Gtk.TreeViewColumn {Title="Email"}; 
    
        Gtk.CellRendererText emailCell = new Gtk.CellRendererText ();
    
        emailColumn.PackStart (emailCell, true);
    
    
    
    
    
    
    
        // Add the columns to the TreeView
    
        tv.AppendColumn (nameColumn);
    
        tv.AppendColumn (emailColumn);
    
    
    
    
    
    
    
        // Tell the Cell Renderers which items in the model to display
    
        nameColumn.AddAttribute (nameCell, "text", 0);
    
        emailColumn.AddAttribute (emailCell, "text", 1);
    
    
    
    
    
    
    
        // Create a model that will hold two strings 
    
        Gtk.TreeStore contacts = new Gtk.TreeStore (typeof (string), typeof (string));
    
    
    
    
    
        // Add some hierarchical data
    
    
    
        Gtk.TreeIter treeiter;
    
    
    
    
    
        //first root
    
        treeiter= contacts.AppendValues("testFRIENDS"); 
    
    
    
            // 2 children of first root
    
            contacts.AppendValues(treeiter, "testOgre", "stinky@hotmale.com");
    
            contacts.AppendValues(treeiter, "testBee", "stingy@coolguy.com");
    
    
    
    
    
    
    
        // second root
    
        treeiter= contacts.AppendValues("RELATIVES"); 
    
    
    
            // 3 children of second root
    
            contacts.AppendValues (treeiter,"Mommy","mother@family.com");
    
            contacts.AppendValues (treeiter,"Daddy", "father@family.com");
    
            contacts.AppendValues (treeiter,"tom", "cousin@family.com");
    
    
    
    
    
    
    
    
    
        filter = new Gtk.TreeModelFilter (contacts, null);
    
    
    
        // Specify the function that determines which rows to filter out and which ones to display
    
        filter.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
    
    
    
        // Assign the filter as our treeview's model
    
        tv.Model = filter;
    
    
    
        // Show the window and everything on it
    
        window.ShowAll ();
    
    }
    
    
    
    private void OnFilterEntryTextChanged (object o, System.EventArgs args)
    
    {
    
        // Since the filter text changed, tell the filter to re-determine which rows to display
    
        filter.Refilter ();
    
    }
    
    
    
    private bool FilterTree (Gtk.TreeModel model, Gtk.TreeIter iter)
    
    {
    
        string contactname = model.GetValue (iter, 0).ToString ();
    
    
    
        if (filterEntry.Text == "")
    
            return true;
    
    
    
        if (contactname.IndexOf (filterEntry.Text) > -1)
    
            return true;
    
        else
    
            return false;
    
    }
