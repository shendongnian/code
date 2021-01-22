    //Create and Initialize the contextMenuStrip component
    contextMenuStrip_ListaAulas = new ContextMenuStrip();
    
    //Adding an Item
    contextMenuStrip_ListaAulas.Items.Add("Modificar");
    
    //Binding the contextMenuStrip with the ListBox
    listBox_Aulas.ContextMenuStrip = contextMenuStrip_ListaAulas;
    
    //The solution below 
    if (e.Button == System.Windows.Forms.MouseButtons.Right)
    {
        //select the item under the mouse pointer
        listBox_Aulas.SelectedIndex = listBox_Aulas.IndexFromPoint(e.Location);
    
        //if the selected index is an item, binding the context MenuStrip with the listBox
        if (listBox_Aulas.SelectedIndex != -1)
        {
             listBox_Aulas.ContextMenuStrip = contextMenuStrip_ListaAulas;  
        }
        //else, untie the contextMenuStrip to the listBox 
        else
        {
             listBox_Aulas.ContextMenuStrip = null;
        }
    }
