	private UpdateDataSource()
	{
		dataGridView2.Rows.Clear();
		dataGridView2.Refresh();
		dtAll.Clear();
		
		if(dt1 == null && dt2 != null)
		{
			dtAll = dt2;
		}
		else if(dt2 == null && dt1 != null)
		{
			dtAll = dt1;
		}
		else if(dt1 != null && dt2 != null)
		{
			dtAll = dt1.Copy();
			dtAll.Merge(dt2);
		}
		else
		{
			dtAll = null;
		}
		dataGridView2.DataSource = dtAll;
	}
	
