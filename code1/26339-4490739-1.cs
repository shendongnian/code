      Public class MyConnection
          Implements IDbConnection
            
          Private itsConnection as IDbConnection
          Private itsTransaction as IDbTransaction
        
          Public Sub New(ByVal conn as IDbConnection)
             itsConnection = conn
          End Sub
        
          //...  'All the implementations would look like
          Public Sub Dispose() Implements IDbConnection.Dispose
             itsConnection.Dispose()
          End Sub
          //...
        
          //     'Except BeginTransaction which would look like
           Public Overridable Function BeginTransaction() As IDbTransaction Implements IDbConnection.BeginTransaction
             itsTransaction = itsConnection.BeginTransaction()
             Return itsTransaction
           End Function  
        
        
          // 'Now you can create a property and use it everywhere without any hacks
           Public ReadOnly Property Transaction
              Get
                  return itsTransaction
              End Get
           End Property
        
        End Class
