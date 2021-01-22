    public List<string> ListSheetInExcel(string filePath)
    {
       OleDbConnectionStringBuilder sbConnection = new OleDbConnectionStringBuilder();
       String strExtendedProperties = String.Empty;
       sbConnection.DataSource = filePath;
       if (Path.GetExtension(filePath).Equals(".xls"))//for 97-03 Excel file
       {
          sbConnection.Provider = "Microsoft.Jet.OLEDB.4.0";
          strExtendedProperties = "Excel 8.0;HDR=Yes;IMEX=1";//HDR=ColumnHeader,IMEX=InterMixed
       }
       else if (Path.GetExtension(filePath).Equals(".xlsx"))  //for 2007 Excel file
       {
          sbConnection.Provider = "Microsoft.ACE.OLEDB.12.0";
          strExtendedProperties = "Excel 12.0;HDR=Yes;IMEX=1";
       }
       sbConnection.Add("Extended Properties",strExtendedProperties);
       using (OleDbConnection conn = new OleDbConnection(sbConnection.ToString()))
       {
         conn.Open();
         DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
         List<string> listSheet = new List<string>();
         foreach (DataRow drSheet in dtSheet.Rows)
         {
            if (drSheet["TABLE_NAME"].ToString().Contains("$"))//checks whether row contains '_xlnm#_FilterDatabase' or sheet name(i.e. sheet name always ends with $ sign)
            {
                 listSheet.Add(drSheet["TABLE_NAME"].ToString());
            } 
         }
      }
     return listSheet;
    }
