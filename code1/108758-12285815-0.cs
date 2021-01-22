    private void textBoxPlatypusNumber_KeyDown(object sender, KeyEventArgs e) {
    	if (e.KeyCode == Keys.Enter)
    	{
    		UpdatePlatypusGrid(); 
    	}
    }
    
    private void UpdatePlatypusGrid()
    {
    	MessageBox.Show("UpdatePlatypusGrid() entered");
    }
