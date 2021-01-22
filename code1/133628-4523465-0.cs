    Private Function CloneEntity(Of TEntity)(ByVal entity As TEntity) As TEntity
    
        Dim dataContext As New DataContext()
        Dim entityType As System.Type = GetType(TEntity)
    
        ' If the purpose of the clone is just to attach it the existing entity to a new
        ' DataContext, you can use IdentityMembers in place of PersistantDataMembers. Setting
        ' only the IdentityMembers is enough to allow for attaching the clone as an "originaL"
        ' entity to the DataContext.
        Dim dataMembers = dataContext.Mapping.GetTable(entityType).RowType.PersistentDataMembers
    
        Dim clone As TEntity ' Do something here to create an entity of the desired type. 
        Dim boxedClone As Object = clone
        For Each dm In dataMembers
    
             ' Depending on how your ColumnAttribute is set, you would use StorageAccessor if
             ' the Storage property is set. Otherwise, you would use MemberAccessor instead.
              dm.StorageAccessor.SetBoxedValue(boxedClone, dm.StorageAccessor.GetBoxedValue(entity))
        Next
    
        Return clone
    
    End Function
