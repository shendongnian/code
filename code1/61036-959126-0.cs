    using System;
    using Gtk;
    public partial class MainWindow: Gtk.Window
    {	
	NodeView myNodeView;
	NodeStore store;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		store = new Gtk.NodeStore (typeof (MyTreeNode));
        store.AddNode (new MyTreeNode ("Item A"));
        store.AddNode (new MyTreeNode ("Item B"));
        store.AddNode (new MyTreeNode ("Item C"));
		
	 	myNodeView = new NodeView(store);
		myNodeView.ButtonPressEvent += new ButtonPressEventHandler(OnItemButtonPressed);
 
        myNodeView.AppendColumn ("Deletable items", new Gtk.CellRendererText (), "text", 0);
        myNodeView.ShowAll ();
		Add (myNodeView);
	}
		    
	[GLib.ConnectBeforeAttribute]
	protected void OnItemButtonPressed (object sender, ButtonPressEventArgs e)
	{
		if (e.Event.Button == 3) /* right click */
		{
			Menu m = new Menu();
			MenuItem deleteItem = new MenuItem("Delete this item");
			deleteItem.ButtonPressEvent +=	new ButtonPressEventHandler(OnDeleteItemButtonPressed);
			m.Add(deleteItem);
			m.ShowAll();
			m.Popup();
		}
	}	                                                        
			                                                        
	protected void OnDeleteItemButtonPressed (object sender, ButtonPressEventArgs e)
	{
		MyTreeNode node = (MyTreeNode)myNodeView.NodeSelection.SelectedNode;
		store.RemoveNode(node);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
    }
    public class MyTreeNode : Gtk.TreeNode {
        public MyTreeNode (string text)
        {
        	ItemText=text;
        }
        [Gtk.TreeNodeValue (Column=0)]
        public string ItemText {get; set;}
    }
