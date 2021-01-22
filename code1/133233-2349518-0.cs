	// Add a reference to Microsoft.SqlServer.Smo
	// Add a reference to Microsoft.SqlServer.ConnectionInfo
	// Add a reference to Microsoft.SqlServer.SqlEnum
	 
	using Microsoft.SqlServer.Management.Smo;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Data;
	 
	public class SqlServerController
	{
	 
		private Server m_server = null;
	 
		public SqlServerController(string server)
		{
			m_server = new Server(server);
		}
	 
		public void AttachDatabase(string database, StringCollection files,
            AttachOptions options)
		{
			m_server.AttachDatabase(database, files, options);
		}
	 
		public void AddBackupDevice(string name)
		{
			BackupDevice device = new BackupDevice(m_server, name);
			m_server.BackupDevices.Add(device);
		}
	 
		public string GetServerVersion(string serverName)
		{
			return m_server.PingSqlServerVersion(serverName).ToString();
		}
	 
		public int CountActiveConnections(string database)
		{
			return m_server.GetActiveDBConnectionCount(database);
		}
	 
		public void DeleteDatabase(string database)
		{
			m_server.KillDatabase(database);
		}
	 
		public void DetachDatabase(string database, bool updateStatistics, 
            bool removeFullTextIndex)
		{
			m_server.DetachDatabase(database, updateStatistics, removeFullTextIndex);
		}
	 
		public void CreateDatabase(string database)
		{
			Database db = new Database(m_server, database);
			db.Create();
		}
	 
		public void CreateTable(string database, string table, 
            List<Column> columnList, List<Index> indexList)
		{
			Database db = m_server.Databases[database];
			Table newTable = new Table(db, table);
	 
			foreach (Column column in columnList)
				newTable.Columns.Add(column);
	 
			if (indexList != null)
			{
				foreach (Index index in indexList)
					newTable.Indexes.Add(index);
			}
	 
			newTable.Create();
	 
		}
	 
		public Column CreateColumn(string name, DataType type, string @default,
            bool isIdentity, bool nullable)
		{
			Column column = new Column();
	 
			column.DataType = type;
			column.Default = @default;
			column.Identity = isIdentity;
			column.Nullable = nullable;
	 
			return column;
		}
	 
		public Index CreateIndex(string name, bool isClustered, IndexKeyType type,
		  string[] columnNameList)
		{
	 
			Index index = new Index();
	 
			index.Name = name;
			index.IndexKeyType = type;
			index.IsClustered = isClustered;
	 
			foreach (string columnName in columnNameList)
				index.IndexedColumns.Add(new IndexedColumn(index, columnName));
	 
			return index;
		}
	 
	}
	 
