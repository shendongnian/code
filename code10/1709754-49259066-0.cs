    private void ExportData()
    {
		//You only need to do this once, take it out of the loop.
		if (!Directory.Exists(ExportPath + dataFilePath.Name))
			Directory.CreateDirectory(ExportPath + dataFilePath.Name);
		var fileNum = 0;
		var rowCount = 0;
			
		while (rowCount < dataGridView1.RowCount)
        {
            fileNum = fileNum + 1;
			
			using (StreamWriter sw = new StreamWriter(ExportPath + dataFilePath.Name + @"\" + dataFilePath.Name + "_" + fileNum + ".csv")
			{
				sw.WriteLine("Unit,UPC,Brand,Vendor,List Cost,QTY,Price,Description,Attribute 1,Attribute 2," +
					"Descriptor 1,Descriptor 2,Descriptor 3,Descriptor 4,Descriptor 5,Descriptor 6,Descriptor 7,Descriptor 8");
				for (int i = 0; i < 50000; i++)
				{
					rowCount = rowCount + 1;
					if (rowCount >= dataGridView1.RowCount)
						break;
					var cells = dataGridView1.Rows[rowCount].Cells.Cast<DataGridViewCell>();
					sw.WriteLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
				}
			}	//sw.Close() and sw.Dispose() not needed because of the 'using'. You may want to do sw.Flush().
		}
		//The 'else' part of your original recursive method
		progressBar1.BeginInvoke(new MethodInvoker(delegate {
            progressBar1.Style = ProgressBarStyle.Blocks;
            button_OpenDataFile.Enabled = true;
            button_ConvertFromRaw.Enabled = true;
            button_exportLS.Enabled = true;
            Console.WriteLine("[Main] Export complete.");
        }));
    }
