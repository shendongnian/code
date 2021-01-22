    using System;
	using System.Data.SqlClient;
	using Microsoft.SqlServer.Management.Common;
	using Microsoft.SqlServer.Management.Smo;
	public class DatabaseRestoreHelper
	{
		private const string _SingleUserCmd = "ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
		private const string _MultiUserCmd = "ALTER DATABASE {0} SET MULTI_USER";
		public static void RestoreDatabase(string connectionString, string backupSetPath, bool verify)
		{
			SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder(connectionString);
			string database = cb.InitialCatalog;
			cb.InitialCatalog = "master";
			SqlConnection sqlConnection = new SqlConnection(cb.ConnectionString);
			ServerConnection serverConnection = new ServerConnection(sqlConnection);
			try
			{
				//Make Database Single User
				serverConnection.ExecuteNonQuery(String.Format(_SingleUserCmd, database));
				Server server = new Server(serverConnection);
				Restore restore = new Restore();
				BackupDeviceItem destination = new BackupDeviceItem(backupSetPath, DeviceType.File);
				restore.Action = RestoreActionType.Database;
				restore.Database = database;
				restore.Devices.Add(destination);
				restore.ReplaceDatabase = true;
				if (verify)
				{
					string errorMessage;
					if (!restore.SqlVerify(server, out errorMessage))
					{
						throw new Exception(errorMessage);
					}
				}
				restore.SqlRestore(server);
			}
			catch
			{
				throw;
			}
			finally
			{
				//Make Database Multi User
				serverConnection.ExecuteNonQuery(String.Format(_MultiUserCmd, database));
				serverConnection.Disconnect();
			}
		}
		public static void BackupDatabase(string connectionString, string backupSetPath, bool verify)
		{
			SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder(connectionString);
			string database = cb.InitialCatalog;
			cb.InitialCatalog = "master";
			SqlConnection sqlConnection = new SqlConnection(cb.ConnectionString);
			ServerConnection serverConnection = new ServerConnection(sqlConnection);
			try
			{
				//Make Database Single User
				serverConnection.ExecuteNonQuery(String.Format(_SingleUserCmd, database));
				Server server = new Server(serverConnection);
				Backup backup = new Backup();
				BackupDeviceItem destination = new BackupDeviceItem(backupSetPath, DeviceType.File);
				backup.Action = BackupActionType.Database;
				backup.Database = database;
				backup.Devices.Add(destination);
				backup.SqlBackup(server);
				if (verify)
				{
					Restore restore = new Restore();
					restore.Action = RestoreActionType.Database;
					restore.Database = database;
					restore.Devices.Add(destination);
					restore.ReplaceDatabase = true;
					string errorMessage;
					if (!restore.SqlVerify(server, out errorMessage))
					{
						throw new Exception(errorMessage);
					}
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				//Make Database Multi User
				serverConnection.ExecuteNonQuery(String.Format(_MultiUserCmd, database));
				serverConnection.Disconnect();
			}
		}
	}
