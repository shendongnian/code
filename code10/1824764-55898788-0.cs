    public DataTable SapDataTableToDotNetDataTable(string pathToXmlFile)
    {
      var DT = new DataTable();
    
      var XMLstream = new System.IO.FileStream(pathToXmlFile, FileMode.Open);
    
      var XDoc = System.Xml.Linq.XDocument.Load(XMLstream);
    
      var Columns = XDoc.Element("DataTable").Element("Columns").Elements("Column");
    
      foreach (var Column in Columns)
      {
        DT.Columns.Add(Column.Attribute("Uid").Value);
      }
    
      var Rows = XDoc.Element("DataTable").Element("Rows").Elements("Row");
    
      var Names = new List<string>();
      foreach (var Row in Rows)
      {
        var DTRow = DT.NewRow();
    
        var Cells = Row.Element("Cells").Elements("Cell");
        foreach (var Cell in Cells)
        {
          var ColName = Cell.Element("ColumnUid").Value;
          var ColValue = Cell.Element("Value").Value;
          DTRow[ColName] = ColValue;
        }
    
        DT.Rows.Add(DTRow);
      }
    
      return DT;
    }
