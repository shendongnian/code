        for (int row = 8; row <= 50; row++)
            { 
                IssueRef.Add(ExcelWksht1.Cells[row, 1].Value.ToString());
                Date.Add(ExcelWksht1.Cells[row, 4].Value.ToString());
                Status.Add(ExcelWksht1.Cells[row, 2].Value.ToString());
                Severity.Add(ExcelWksht1.Cells[row, 9].Value.ToString());
                Text.Add(ExcelWksht1.Cells[row, 3].Value.ToString());
    
                decimal ProgressVal = ( 10m /50m) * 100m;
                int Val = Convert.ToInt32(ProgressVal);
    
                OpenForm.progressBar1.Value = Val;
                //OpenForm.progressBar1.Refresh(); remove this
    //add 
    Application.DoEvents();
    
            }
