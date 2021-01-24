    Public Overrides Function SaveChanges() As Integer
       For Each changedEntity In Me.ChangeTracker.Entries
           Select Case If(changedEntity.Entity.GetType.Namespace = "System.Data.Entity.DynamicProxies", changedEntity.Entity.GetType.BaseType, changedEntity.Entity.GetType)
               Case GetType(YourEntityType)
                   If changedEntity.State = EntityState.Added OrElse changedEntity.State = EntityState.Modified OrElse changedEntity.State = EntityState.Deleted Then
                      NotifyUser(changedEntity)
                   End If
           End Select
       Next 
    End Function
