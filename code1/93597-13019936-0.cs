    	DataGridViewColumn c = new DataGridViewColumn();
 		DataGridViewCell cell = new DataGridViewTextBoxCell();
   
   		c.CellTemplate = cell;
   		c.HeaderText = "added";
   		c.Name = "added";
   		c.Visible = true;
    dgv.Columns.Insert(0, c); 
