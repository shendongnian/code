Remember to use Path from System.IO;!
            string tempXlsFilePathName;
            string result = new string;
            string sheetName;
            string queryString;
            int successCounter;
            // set sheetName and queryString
            sheetName = "sheetName";
            queryString = "CREATE TABLE " + sheetName + "([columnTitle] char(255))";
                    
            // Write .xls
            successCounter = 0;
            tempXlsFilePathName = (_tempXlsFilePath + @"\literalFilename.xls");
            using (OleDbConnection connection = new OleDbConnection(GetConnectionString(tempXlsFilePathName)))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                yourCollection.ForEach(dataItem=>
                {
                    string SQL = "INSERT INTO [" + sheetName + "$] VALUES ('" + dataItem.ToString() + "')";
                    OleDbCommand updateCommand = new OleDbCommand(SQL, connection);
                    updateCommand.ExecuteNonQuery();
                    successCounter++;
                }
                );
                // update result with successfully written username filepath
                result = tempXlsFilePathName;
            }
            _successfulRowsCount = successCounter;
            return result;
