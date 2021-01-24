    public DocAdmin.GHDefinitionDataTable ConvertDataTable(DataTable dtOriginal)
    {
        DocAdmin.GHDefinitionDataTable ghDefiniton = new DocAdmin.GHDefinitionDataTable();
        int ExcelRowNumber = 1;
        foreach (DataRow row in dtOriginal.Rows)
        {
            ++ExcelRowNumber;
            try
            {
                ghDefinition.ImportRow(row);
            }
            catch (ArgumentException ex)
            {
              System.Windows.Forms.MessageBox.Show("Error on line " + ExcelRowNumber)
            }
        }
        return ghDefinition;
    }
