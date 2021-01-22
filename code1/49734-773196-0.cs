    class XmlCsvImport
    {
        public void ImportData(string xmlData, ConnectionStringSettings connectionSettings)
	    {
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(connectionSettings.ProviderName);
            IDbConnection connection = providerFactory.CreateConnection();
            connection.ConnectionString = connectionSettings.ConnectionString;
            // TODO: Begin transaction
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            foreach (XmlNode tableNode in doc.SelectNodes("/transaction/table"))
            {
                IDbCommand command = CreatCommand(connection, tableNode);
                foreach (XmlNode rowNode in tableNode.SelectNodes("data/row"))
                {
                    string[] values = GetRowValues(rowNode);
                    if (values.Length != command.Parameters.Count)
                    {
                        // TODO: Log bad row
                        continue;
                    }
                    this.FillCommand(command, values);
                    command.ExecuteNonQuery();
                }
            }
            // TODO: Commit transaction
	    }
        private IDbCommand CreatCommand(IDbConnection connection, XmlNode tableNode)
        {
            string tableName = tableNode.Attributes["name"].Value;
            IDbCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            XmlNodeList fieldNodes = tableNode.SelectNodes("fields/field");
            List<string> fieldNameList = new List<string>(fieldNodes.Count);
            foreach (XmlNode fieldNode in tableNode.SelectNodes("fields/field"))
            {
                string fieldName = fieldNode.Attributes["name"].Value;
                int fieldType = Int32.Parse(fieldNode.Attributes["type"].Value);
                int fieldSize = Int32.Parse(fieldNode.Attributes["size"].Value);
                IDbDataParameter param = command.CreateParameter();
                param.ParameterName = String.Concat("@", fieldNode.Attributes["name"]);
                param.Size = fieldSize;
                param.DbType = (DbType)fieldType; // NOTE: this may not be so easy
                command.Parameters.Add(param);
                fieldNameList.Add(fieldName);
            }
            string[] fieldNames = fieldNameList.ToArray();
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.AppendFormat("INSERT INTO [{0}] (", tableName);
            string columnNames = String.Join("], [", fieldNames);
            string paramNames = String.Join(", @", fieldNames);
            command.CommandText = String.Concat(
                "INSERT INTO [", tableName, "] ([",
                columnNames,
                "]) VALUES (@",
                paramNames,
                ")"
                );
            return command;
        }
        private string[] GetRowValues(XmlNode row)
        {
            List<string> values = new List<string>();
            foreach (XmlNode child in row.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Text ||
                    child.NodeType == XmlNodeType.CDATA)
                {
                    values.Add(child.Value);
                }
            }
            return values.ToArray();
        }
        private void FillCommand(IDbCommand command, string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                IDbDataParameter param = (IDbDataParameter)command.Parameters[i];
                param.Value = values[i]; // TODO: Convert to correct data type
            }
        }
