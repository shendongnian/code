    private void ReadExcelData(string filename)
    {
        FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read);
        IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
        reader.IsFirstRowAsColumnNames = true;
        result = reader.AsDataSet();
        cboSheet.Items.Clear();
        cboSheet_mirror.Items.Clear();
        resultSheet.Items.Clear();
        foreach (System.Data.DataTable dt in result.Tables)
        {
            cboSheet.Items.Add(dt.TableName);
            cboSheet_mirror.Items.Add(dt.TableName);
            resultSheet.Items.Add(dt.TableName);
        }
        reader.Close();
    }
