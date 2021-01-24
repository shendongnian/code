    using System;
    using System.Windows.Forms;
    
    namespace MyTreeViewDemo
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
    
                //Load the tree view
                myTreeView1.Load();
    
                //Subscribe to the MyTreeView ContextMenuItemClicked event. 
                // Set it to invoke MyTreeView1_FooClicked when the event is raised
                myTreeView1.ContextMenuItemClicked += MyTreeView1_FooClicked;
            }
    
            void MyTreeView1_FooClicked(object sender, EventArgs e)
            {
                // Do form stuff (other than treeview stuff) that needs to be done when a treenode context menu item is clicked
            }
        }
    }
	
