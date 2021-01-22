        Public MustInherit Class DBConnectionDetail
        'note this abstract class could be an interface if you didn't want these common methods
        Protected _conStrBldr As New Npgsql.NpgsqlConnectionStringBuilder
        Protected _connection As Npgsql.NpgsqlConnection
        Public Sub New()
            'Set the connection builder properties in the subclass
        End Sub
        Friend ReadOnly Property ConnectionStringBuilder() As Npgsql.NpgsqlConnectionStringBuilder
            Get
                Return _conStrBldr
            End Get
        End Property
        Friend Property Connection() As Npgsql.NpgsqlConnection
            Get
                Return _connection
            End Get
            Set(ByVal value As Npgsql.NpgsqlConnection)
                _connection = value
            End Set
        End Property
        ' Misc properties - information for programmers of higher layers
        Public MustOverride ReadOnly Property Description() As String
        Public MustOverride ReadOnly Property HostName() As String
        Public MustOverride ReadOnly Property IP() As String
        Public MustOverride ReadOnly Property Database() As String
    End Class
     Public Class LocalArchiveConnectionDetails
        Inherits DBConnectionDetail
        Public Sub New()
            _conStrBldr.Host = "localhost"
            _conStrBldr.Port = 5432
            _conStrBldr.UserName = "usr"
            _conStrBldr.Password = "pwd"
            _conStrBldr.Database = "archive"
            '_conStrBldr.Pooling = True
            '_conStrBldr.MinPoolSize = 5
            '_conStrBldr.MaxPoolSize = 10
            '_conStrBldr.CommandTimeout = 1024
            '_conStrBldr.Timeout = 1024
            '_conStrBldr.ConnectionLifeTime = 2
        End Sub
        Public Overrides ReadOnly Property Description() As String
            Get
                Return "Local Connection to Database"
            End Get
        End Property
        Public Overrides ReadOnly Property Database() As String
            Get
                Return "archive"
            End Get
        End Property
        Public Overrides ReadOnly Property HostName() As String
            Get
                Return "local host"
            End Get
        End Property
        Public Overrides ReadOnly Property IP() As String
            Get
                Return "127.0.0.1"
            End Get
        End Property
    End Class
    Public Interface IConnectionFactory
        ReadOnly Property GetMasterConnection() As DBConnectionDetail
        ReadOnly Property GetWarehouseConnection() As DBConnectionDetail
        ReadOnly Property GetArchiveConnection() As DBConnectionDetail
        ReadOnly Property GetAuditConnection() As DBConnectionDetail
    End Interface
        Public Class DBConnectionBuilder
        Friend Shared Function GetConnection(ByVal conStrBldr As DBConnectionDetail) As NpgsqlConnection
            Return New NpgsqlConnection(conStrBldr.ConnectionStringBuilder.ConnectionString)
        End Function
        'Friend Shared Function GetConnection(ByVal conStr As String) As NpgsqlConnection
        '    Return New NpgsqlConnection(conStr)
        'End Function
    End Class
        Public Class LocalConnectionFactory
        Implements IConnectionFactory
        Public ReadOnly Property GetArchiveConnection() As DBConnectionDetail Implements IConnectionFactory.GetArchiveConnection
            Get
                Dim dbConnection As New LocalArchiveConnectionDetails
                dbConnection.Connection = DBConnectionBuilder.GetConnection(dbConnection)
                Return dbConnection
            End Get
        End Property
        Public ReadOnly Property GetMasterConnection() As DBConnectionDetail Implements IConnectionFactory.GetMasterConnection
            Get
                Dim dbConnection As New LocalMasterConnectionDetails
                dbConnection.Connection = DBConnectionBuilder.GetConnection(dbConnection)
                Return dbConnection
            End Get
        End Property
        Public ReadOnly Property GetWarehouseConnection() As DBConnectionDetail Implements IConnectionFactory.GetWarehouseConnection
            Get
                Dim dbConnection As New LocalWarehouseConnectionDetails
                dbConnection.Connection = DBConnectionBuilder.GetConnection(dbConnection)
                Return dbConnection
            End Get
        End Property
        Public ReadOnly Property GetAuditConnection() As DBConnectionDetail Implements IConnectionFactory.GetAuditConnection
            Get
                Dim dbConnection As New LocalAuditConnectionDetails
                dbConnection.Connection = DBConnectionBuilder.GetConnection(dbConnection)
                Return dbConnection
            End Get
        End Property
    End Class
     ''' <summary>
    ''' The custom connection factory allows higher layers to decide which connection will be returned by the connection proxy
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CustomConnectionFactory
        Implements IConnectionFactory
        Private _archiveConnection As DBConnectionDetail
        Private _masterConnection As DBConnectionDetail
        Private _warehouseConnection As DBConnectionDetail
        Private _auditConnection As DBConnectionDetail
        Friend Sub New()
        End Sub
        Friend Sub New(ByVal masterConnection As DBConnectionDetail, ByVal archiveConnection As DBConnectionDetail, _
                       ByVal warehouseConnection As DBConnectionDetail, ByVal auditConnection As DBConnectionDetail)
            _masterConnection = masterConnection
            _archiveConnection = archiveConnection
            _warehouseConnection = archiveConnection
            _auditConnection = auditConnection
        End Sub
        Friend Sub SetMasterConnectionDetail(ByVal connectionDetail As DBConnectionDetail)
            _masterConnection = connectionDetail
        End Sub
        Friend Sub SetArchiveConnectionDetail(ByVal connectionDetail As DBConnectionDetail)
            _archiveConnection = connectionDetail
        End Sub
        Friend Sub SetWarehouseConnectionDetail(ByVal connectionDetail As DBConnectionDetail)
            _warehouseConnection = connectionDetail
        End Sub
        Friend Sub SetAuditConnectionDetail(ByVal connectionDetail As DBConnectionDetail)
            _auditConnection = connectionDetail
        End Sub
        Public ReadOnly Property GetArchiveConnection() As DBConnectionDetail Implements IConnectionFactory.GetArchiveConnection
            Get
                _archiveConnection.Connection = DBConnectionBuilder.GetConnection(_archiveConnection)
                Return _archiveConnection
            End Get
        End Property
        Public ReadOnly Property GetMasterConnection() As DBConnectionDetail Implements IConnectionFactory.GetMasterConnection
            Get
                _masterConnection.Connection = DBConnectionBuilder.GetConnection(_masterConnection)
                Return _masterConnection
            End Get
        End Property
        Public ReadOnly Property GetWarehouseConnection() As DBConnectionDetail Implements IConnectionFactory.GetWarehouseConnection
            Get
                _warehouseConnection.Connection = DBConnectionBuilder.GetConnection(_warehouseConnection)
                Return _warehouseConnection
            End Get
        End Property
        Public ReadOnly Property GetAuditConnection() As DBConnectionDetail Implements IConnectionFactory.GetAuditConnection
            Get
                _auditConnection.Connection = DBConnectionBuilder.GetConnection(_auditConnection)
                Return _auditConnection
            End Get
        End Property
    End Class
     Public Class DBConnectionsProxy
        Private _ConnectionsFactory As IConnectionFactory
        Private _CurrentConnectionsFactory As IConnectionFactory
        Public Sub New(ByVal connectionFactory As IConnectionFactory)
            'check that a connection factory is provided otherwise nothing will work
            If connectionFactory Is Nothing Then
                Throw New NullReferenceException("You must provide a connection factory")
            Else
                _ConnectionsFactory = connectionFactory
                _CurrentConnectionsFactory = connectionFactory
            End If
        End Sub
        Friend Property ConnectionFactory() As IConnectionFactory
            Get
                Return _CurrentConnectionsFactory
            End Get
            Set(ByVal value As IConnectionFactory)
                _CurrentConnectionsFactory = value
            End Set
        End Property
        Public ReadOnly Property GetMasterConnection() As Npgsql.NpgsqlConnection
            Get
                Return _CurrentConnectionsFactory.GetMasterConnection.Connection
            End Get
        End Property
        Public ReadOnly Property GetArchiveConnection() As Npgsql.NpgsqlConnection
            Get
                Return _CurrentConnectionsFactory.GetArchiveConnection.Connection
            End Get
        End Property
        Public ReadOnly Property GetWarehouseConnection() As Npgsql.NpgsqlConnection
            Get
                Return _CurrentConnectionsFactory.GetWarehouseConnection.Connection
            End Get
        End Property
        Public ReadOnly Property GetAuditConnection() As Npgsql.NpgsqlConnection
            Get
                Return _CurrentConnectionsFactory.GetAuditConnection.Connection
            End Get
        End Property
        ''' <summary>
        ''' Reset current connection factory to original connection factory this proxy was instantiated with
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ResetConnection()
            _CurrentConnectionsFactory = _ConnectionsFactory
        End Sub
        ''' <summary>
        ''' Changes the master connection returned for the current connection factory
        ''' </summary>
        ''' <param name="connectionDetail">Connection information for master database</param>
        ''' <remarks></remarks>
        Public Sub SetMasterConnection(ByVal connectionDetail As DBConnectionDetail)
            Me.SetAllConnections(connectionDetail, _CurrentConnectionsFactory.GetArchiveConnection, _
                                 _CurrentConnectionsFactory.GetWarehouseConnection, _CurrentConnectionsFactory.GetAuditConnection)
        End Sub
        ''' <summary>
        ''' Changes the archive connection returned for the current connection factory
        ''' </summary>
        ''' <param name="connectionDetail">Connection information for archive database</param>
        ''' <remarks></remarks>
        Public Sub SetArchiveConnection(ByVal connectionDetail As DBConnectionDetail)
            Me.SetAllConnections(_CurrentConnectionsFactory.GetMasterConnection, connectionDetail, _
                                 _CurrentConnectionsFactory.GetWarehouseConnection, _CurrentConnectionsFactory.GetAuditConnection)
        End Sub
        ''' <summary>
        ''' Changes the warehouse connection returned for the current connection factory
        ''' </summary>
        ''' <param name="connectionDetail">Connection information for warehouse database</param>
        ''' <remarks></remarks>
        Public Sub SetWarehouseConnection(ByVal connectionDetail As DBConnectionDetail)
            Me.SetAllConnections(_CurrentConnectionsFactory.GetMasterConnection, _CurrentConnectionsFactory.GetArchiveConnection, _
                                 connectionDetail, _CurrentConnectionsFactory.GetAuditConnection)
        End Sub
        ''' <summary>
        ''' Changes the audit connection returned for the current connection factory
        ''' </summary>
        ''' <param name="connectionDetail">Connection information for audit database</param>
        ''' <remarks></remarks>
        Public Sub SetAuditConnection(ByVal connectionDetail As DBConnectionDetail)
            Me.SetAllConnections(_CurrentConnectionsFactory.GetMasterConnection, _CurrentConnectionsFactory.GetArchiveConnection, _
                                 _CurrentConnectionsFactory.GetWarehouseConnection, connectionDetail)
        End Sub
        ''' <summary>
        ''' Sets the current connection factory to a custom connection factory using the supplied connection
        ''' </summary>
        ''' <param name="masterConnectionDetail">Connection information for master database</param>
        ''' <param name="archiveConnectionDetail">Connection information for archive database</param>
        ''' <param name="warehouseConnectionDetail">Connection information for warehouse database</param>
        ''' <remarks></remarks>
        Public Sub SetAllConnections(ByVal masterConnectionDetail As DBConnectionDetail, _
                                     ByVal archiveConnectionDetail As DBConnectionDetail, _
                                     ByVal warehouseConnectionDetail As DBConnectionDetail, _
                                     ByVal auditConnectionDetail As DBConnectionDetail)
            Dim customConnFactory As New CustomConnectionFactory
            customConnFactory.SetMasterConnectionDetail(masterConnectionDetail)
            customConnFactory.SetArchiveConnectionDetail(archiveConnectionDetail)
            customConnFactory.SetWarehouseConnectionDetail(warehouseConnectionDetail)
            customConnFactory.SetAuditConnectionDetail(auditConnectionDetail)
            _CurrentConnectionsFactory = customConnFactory
        End Sub
    End Class
