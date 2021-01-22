    Imports Rhino.Commons
    Public Class AuditInterceptor
    Inherits NHibernate.EmptyInterceptor
    Private _auditLogRepository As IAuditLogRepository
    Public Sub New(ByVal [AuditLogRepository] As IAuditLogRepository)
        _auditLogRepository = [AuditLogRepository]
    End Sub
    Public Overrides Function OnFlushDirty(ByVal entity As Object, ByVal id As Object, ByVal currentState() As Object, ByVal previousState() As Object, ByVal propertyNames() As String, ByVal types() As NHibernate.Type.IType) As Boolean
    'Called on an Update
        If TypeOf entity Is IAuditable Then
            Using uow = UnitOfWork.Start(UnitOfWorkNestingOptions.CreateNewOrNestUnitOfWork)
                If TypeOf entity Is [yourObject] Then
                    aLog = New AuditLog(Now, My.User.Name)
                    With aLog
                        .EntityID = id
                        .EntityName = "[yourObject]"
                        .PropertyName = "[yourProperty]"
                        .ActionType = "U"
                        .OldValue = GetPropertyValue("[yourProperty]", previousState, propertyNames)
                        .NewValue = GetPropertyValue("[yourProperty]", currentState, propertyNames)
                    End With
                    _auditLogRepository.Save(aLog)    
                End if
                uow.Flush()
            End Using
        End If
        Return MyBase.OnFlushDirty(entity, id, state, propertyNames, types)
    End Function
    Public Overrides Function OnSave(ByVal entity As Object, ByVal id As Object, ByVal state() As Object, ByVal propertyNames() As String, ByVal types() As NHibernate.Type.IType) As Boolean
    'Called on an Insert
        If TypeOf entity Is IAuditable Then
            'create a new audit log class here
        end if
        Return MyBase.OnSave(entity, id, state, propertyNames, types)
    End Function
