    var datasource = new BindingList<string>( new List<string>( new string[] { "item1" } ) );
    listbox.DataSource = datasource ;
    listbox.ContextMenu = new ContextMenu(
        new MenuItem[] { 
            new MenuItem("Delete", 
                new EventHandler( (s,ev) => 
                datasource.Remove(listbox.SelectedItem.ToString())
            )
        ) 
    });
	
	private void buttonAdd_Click(object sender, EventArgs e)
	{
		datasource.Add( textBox.Text );
	}	
