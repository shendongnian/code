//name of the connection string in the configuration file, Will automatically create a specific type of database connection based on the providerName of the configuration file
Public DbContext (string connectionName)
//connection string, the default returns SQLServer database type, namely: providerName = "System.Data.SqlClient"
Public DbContext (string connectionString)
//Connection string and data provider name
Public DbContext(string connectionString, string providerName)
