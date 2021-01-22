    private void ListBox_MouseDownHandler(object sender, MouseButtonEventArgs e)
    {
    	ListBox parent = (ListBox)sender;
    
    	//get the object source for the selected item
    	object data = GetObjectDataFromPoint(parent, e.GetPosition(parent));
    
    	//if the data is not null then start the drag drop operation
    	if (data != null)
    	{
    		System.Windows.Forms.DataObject dataObject = new System.Windows.Forms.DataObject();
    		dataObject.SetData(typeof(ToolboxItem), data as ToolboxItem);
    		DragDrop.DoDragDrop(this, dataObject, DragDropEffects.Move | DragDropEffects.Copy);
    	}
    }
