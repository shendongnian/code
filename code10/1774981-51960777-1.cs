        private string InsertDescription( string mdbFile )
    {
        string log = null;
        DAO.Database db;
        DAO.DBEngine dbEn = new DAO.DBEngine();
        DAO.Recordset rs;
        string value = "Bi pe di Ba pe di Buuuuuuuuuuuuuuuuuuuuuuu!!!!";
        string tabelName = "TAB";
        string columnName = "dbdb";
        try
        {
            db = dbEn.OpenDatabase(mdbFile, null, false, null);
            rs = db.OpenTable(tabelName, 0);
            rs.AddNew();
            db.TableDefs[tabelName].Fields[columnName].Properties["Description"].Value = value;
            rs.Update(1, false);
            rs.Close();
            log = "- Der Descriptionimport in die Datenbank war erfolgreich!";
        }
        catch( Exception ex )
        {
            log = "- Der Descriptionimport in die Datenbank war Nicht erfolgreich!" + Environment.NewLine + ex.Message;
        }
        return log;
    }
