    // we have a valid file name so we now need to
    // populate the list box with available reports
    listBoxReports.Items.Clear();
    
    // create an application object.
    MsAccess.Application app = new MsAccess.Application();
    // open the access database file.
    app.OpenCurrentDatabase(dlg.FileName, false, "");
    string sql = "SELECT [Name] FROM MSysObjects WHERE Type = -32764";
    dao.Database db = app.CurrentDb();
    // query the database for all the reports.  all this data is
    // contained in the MSysObejcts table which is invisible through
    // the table listing in access.
    dao.Recordset rs = db.OpenRecordset(sql, Type.Missing, Type.Missing, Type.Missing);
    // go through and add all the reports to the list box.
    while (!rs.EOF) {
        listBoxReports.Items.Add(rs.Fields[0].Value);
        rs.MoveNext();
    }
    
    // clean up
    rs.Close();
    rs = null;
    db.Close();
    db = null;
    app.CloseCurrentDatabase();
    app = null;
