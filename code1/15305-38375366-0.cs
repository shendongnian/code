    public class MyClass : UserControl
    {
    	public MyClass()
    	{
    		InitializeComponent();
    	
    		MouseClick += ControlOnMouseClick;
    		if (HasChildren)
    			AddOnMouseClickHandlerRecursive(Controls);
    	}
    
    	private void AddOnMouseClickHandlerRecursive(IEnumerable controls)
    	{
    		foreach (Control control in controls)
    		{
    			control.MouseClick += ControlOnMouseClick;
    
    			if (control.HasChildren)
    				AddOnMouseClickHandlerRecursive(control.Controls);
    		}
    	}
    
    	private void ControlOnMouseClick(object sender, MouseEventArgs args)
    	{
    		if (args.Button != MouseButtons.Right)
    			return;
    
    		var contextMenu = new ContextMenu(new[] { new MenuItem("Copy", OnCopyClick) });
    		contextMenu.Show((Control)sender, new Point(args.X, args.Y));
    	}
    
    	private void OnCopyClick(object sender, EventArgs eventArgs)
    	{
    		MessageBox.Show("Copy menu item was clicked.");
    	}
    }
