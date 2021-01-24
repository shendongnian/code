    public async void btnSort_Click(object sender, EventArgs e)
    {
    	lblStatusUpdate.Text = "Sorting...";
    	await Task.Run(() =>
    		{
    			bubbleSort(iArray);
    			foreach (int item in iArray)
    			{
    				UpdateUI(item);
    			}
    		});
    }
    
    public void UpdateUI(int item)
    {
    	_synchronizationContext.Post(new SendOrPostCallback(o =>
    	{
    		lbxNumbers.Items.Add(o);
    	}), item);
    
    }
