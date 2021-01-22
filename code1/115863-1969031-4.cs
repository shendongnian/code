    if (!this.Items.IsReadOnly)
    {
    	for (int i = this.Items.Count - 1; i >= 0; i--)
    	{
    		this.Items[i].Dispose();
    	}
    	this.Items.Clear();
    }
