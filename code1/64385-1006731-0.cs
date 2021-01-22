    // Summary:
    //     Initializes a new instance of the System.Data.Linq.DataContext class by referencing
    //     the connection used by the .NET Framework.
    //
    // Parameters:
    //   connection:
    //     The connection used by the .NET Framework.
    public DataContext(IDbConnection connection);
    //
    // Summary:
    //     Initializes a new instance of the System.Data.Linq.DataContext class by referencing
    //     a file source.
    //
    // Parameters:
    //   fileOrServerOrConnection:
    //     This argument can be any one of the following: The name of a file where a
    //     SQL Server Express database resides.  The name of a server where a database
    //     is present. In this case the provider uses the default database for a user.
    //      A complete connection string. LINQ to SQL just passes the string to the
    //     provider without modification.
    public DataContext(string fileOrServerOrConnection);
    //
    // Summary:
    //     Initializes a new instance of the System.Data.Linq.DataContext class by referencing
    //     a connection and a mapping source.
    //
    // Parameters:
    //   connection:
    //     The connection used by the .NET Framework.
    //
    //   mapping:
    //     The System.Data.Linq.Mapping.MappingSource.
    public DataContext(IDbConnection connection, MappingSource mapping);
    //
    // Summary:
    //     Initializes a new instance of the System.Data.Linq.DataContext class by referencing
    //     a file source and a mapping source.
    //
    // Parameters:
    //   fileOrServerOrConnection:
    //     This argument can be any one of the following: The name of a file where a
    //     SQL Server Express database resides.  The name of a server where a database
    //     is present. In this case the provider uses the default database for a user.
    //      A complete connection string. LINQ to SQL just passes the string to the
    //     provider without modification.
    //
    //   mapping:
    //     The System.Data.Linq.Mapping.MappingSource.
    public DataContext(string fileOrServerOrConnection, MappingSource mapping);
