    List<DateTime> listDate; //I'm filling it with data from datagridview
    ...
    object[,] outDate = new object[listDate.Count, 1];
    for(int row = 0; row < listDate.Count; row++)
	{
		outDate[row, 0] = listDate[row];
	}
