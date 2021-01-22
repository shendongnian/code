    public static void databaseFilePut(string varFilePath) {
        byte[] file;
        using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read)) {
            using (var reader = new BinaryReader(stream)) {
                file = reader.ReadBytes((int) stream.Length);       
            }          
        }
        using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
        using (var sqlWrite = new SqlCommand("INSERT INTO Raporty (RaportPlik) Values(@File)", varConnection)) {
            sqlWrite.Parameters.Add("@File", SqlDbType.VarBinary, file.Length).Value = file;
            sqlWrite.ExecuteNonQuery();
        }
    }
