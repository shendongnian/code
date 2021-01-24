    using (OracleCommand cmd = new OracleCommand(sql, conn)) {
       cmd.CommandType = CommandType.Text;
       using (OracleDataReader dr = cmd.ExecuteReader()) {
          while (dr.Read()) {
             string buildingId = dr["building_id"].ToString(); // <-- chache building id
             if (buildingId != " " && buildingId != "" && buildingId != null) {
                using (SpreadsheetDocument document = SpreadsheetDocument.Open(path, true)) {
                   IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == buildingId);
                   WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheets.FirstOrDefault().Id);
    
    ...
                }
             }
          }
       }
    }
