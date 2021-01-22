    public static Boolean SaveDocument(Guid candidateId, String fileName, String contentType, Byte[] data) {
        Boolean bResult = false;
        Database db = DatabaseFactory.CreateDatabase(Databases.Hphr.ToString());
        using (DbCommand dbCommand = db.GetStoredProcCommand("CandidateDocumentSave")) {
            db.AddInParameter(dbCommand, "CandidateId", DbType.Guid, candidateId);
            db.AddInParameter(dbCommand, "FileName", DbType.String, fileName);
            db.AddInParameter(dbCommand, "ContentType", DbType.String, contentType);
            db.AddInParameter(dbCommand, "FileType", DbType.String, Path.GetExtension(fileName).Substring(1));
            db.AddInParameter(dbCommand, "Data", DbType.Binary, data);
            db.ExecuteNonQuery(dbCommand);
            bResult = true;
        } // using dbCommand
        return bResult;
    } // method::SaveDocument
