      dataGridView1.Rows.Clear();
            try
            {
                foreach (string fileNames in fileDrive)
                {
    
                    if (regEx.IsMatch(fileNames))
                    {
                        string fileNameOnly = Path.GetFileName(fileNames);
                        string pathOnly = Path.GetDirectoryName(fileNames);
    
                        DataGridViewRow dgr = new DataGridViewRow();
                        filePath.Add(fileNames);
                        dgr.CreateCells(dataGridView1);
                        dgr.Cells[0].Value = pathOnly;
                        dgr.Cells[1].Value = fileNameOnly;
                        dataGridView1.Rows.Add(dgr);
    
                        new SanitizeFileNames.FileCleanup(fileNames);
                    }
    
                    else
                    {
                        continue;
                    }
    
                }
            }
