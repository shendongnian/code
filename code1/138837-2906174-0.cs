    Public Class UnitOfWork
        Implements IUnitOfWork
        Implements IDisposable
        Private ReadOnly Property ObjectContext As Interfaces.IObjectContext
    
        Public Sub New(ByVal objectContext As Interfaces.IObjectContext)
            _objectContext = objectContext
        End Sub
    
        Public Sub Dispose() Implements IDisposable.Dispose
            If _objectContext IsNot Nothing Then
                _objectContext.Dispose()
            End If
            GC.SuppressFinalize(Me)
        End Sub
    
        Public Sub Commit() Implements IUnitOfWork.Commit
            _objectContext.SaveChanges()
        End Sub
    End Class
