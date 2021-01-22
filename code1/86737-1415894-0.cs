    public void Update(TravTasks.TravellerTask data)
    {
    	TreeSelection tsel = this.treeview3.Selection;
    	if (tsel != null)
    	{
    		TreeIter iter = new TreeIter();
    		if (tsel.GetSelected(out iter))
    		{
    			this.tasks_tree_store.SetValue(iter, 0, data.TaskName);
    		}
    	}
    }
