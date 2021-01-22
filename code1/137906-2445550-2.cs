        public static void databaseFilePut(string varFilePath) {
            byte[] file;
            using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read)) {
                using (var reader = new BinaryReader(stream)) {
                    file = reader.ReadBytes((int) stream.Length);
                  
                }
                
            }
            using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetailsDZP))
            using (var sqlWrite = new SqlCommand("INSERT INTO Raporty (RaportPlik) Values(@File)", varConnection)) {
                sqlWrite.Parameters.Add("@File", SqlDbType.VarBinary, file.Length).Value = file;
                sqlWrite.ExecuteNonQuery();
            }
        }
        public static void databaseFileRead(string varID, string varPathToNewLocation) {
            using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetailsDZP))
            using (var sqlQuery = new SqlCommand(@"SELECT [RaportPlik] FROM [dbo].[Raporty] WHERE [RaportID] = @varID", varConnection)) {
                sqlQuery.Parameters.AddWithValue("@varID", varID);
                using (var sqlQueryResult = sqlQuery.ExecuteReader())
                    if (sqlQueryResult != null) {
                        sqlQueryResult.Read();
                        var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                        sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                        using (var fs = new FileStream(varPathToNewLocation, FileMode.Create, FileAccess.Write)) fs.Write(blob, 0, blob.Length);
                    }
            }
        }
        public static MemoryStream databaseFileRead(string varID) {
            MemoryStream memoryStream = new MemoryStream();
            using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetailsDZP))
            using (var sqlQuery = new SqlCommand(@"SELECT [RaportPlik] FROM [dbo].[Raporty] WHERE [RaportID] = @varID", varConnection)) {
                sqlQuery.Parameters.AddWithValue("@varID", varID);
                using (var sqlQueryResult = sqlQuery.ExecuteReader())
                    if (sqlQueryResult != null) {
                        sqlQueryResult.Read();
                        var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                        sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                        //using (var fs = new MemoryStream(memoryStream, FileMode.Create, FileAccess.Write)) {
                        memoryStream.Write(blob, 0, blob.Length);
                        //}
                    }
            }
            return memoryStream;
        }
