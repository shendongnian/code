    for(int i=dataGridViewgrida.Rows.Count - 1; i>=0; i--)
    {
    	var row = dataGridViewgrida.Rows[i];
    	if (row.Cells[1].Value.ToString().Contains(".exe"))
    	{
    		dataGridViewgrida.Rows.RemoveAt(i); // or dataGridViewgrida.Rows.Remove(row );
    	}	
    }
