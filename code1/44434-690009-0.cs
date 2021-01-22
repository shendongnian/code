    using System.Data.Common;
    using System.Globalization;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    Database db = DatabaseFactory.CreateDatabase(DatabaseType.MyDatabase.ToString());
    
    using (DbCommand dbCommand = db.GetStoredProcCommand("dbo.MyStoredProc")) {
    	db.AddInParameter(dbCommand, "identity", DbType.Int32, item.Identity);
    	db.AddInParameter(dbCommand, "name", DbType.String, item.Name);
    	db.AddInParameter(dbCommand, "desc", DbType.String, item.Description);
    	db.AddInParameter(dbCommand, "title", DbType.String, item.Title);
    
    	db.ExecuteNonQuery(dbCommand);
    } // using dbCommand
