    Public Shared Function GetKeyPropertyName(ByVal typeName As String) As String
        Dim props = Type.GetType(typeName).GetProperties
        For Each prop In props
            Dim atts = prop.GetCustomAttributes(True)
            For Each att In atts
                If TypeOf (att) Is EdmScalarPropertyAttribute Then
                    If DirectCast(att, EdmScalarPropertyAttribute).EntityKeyProperty Then
                        Return prop.Name
                    End If
                End If
            Next
        Next
        Throw New ApplicationException(String.Format("No key property found for type '{0}'.", typeName))
    End Function
    Public Shared Function GetObjectById(Of T As EntityObject)(ByVal id As Guid) As T
        Dim ctx = MyContext
        Dim entityType As Type = GetType(T)
        Dim entityTypeName As String = entityType.ToString
        Dim keyProperty As String = GetKeyPropertyName(entityTypeName)
        Dim container = ctx.MetadataWorkspace.GetEntityContainer(ctx.DefaultContainerName, Metadata.Edm.DataSpace.CSpace)
        Dim entitySetName As String = (From meta In container.BaseEntitySets Where meta.ElementType.FullName = entityTypeName Select meta.Name).First()
        Dim entitySetFullName As String = String.Format("{0}.{1}", container.Name, entitySetName)
 
        Dim entityKeyValues As IEnumerable(Of KeyValuePair(Of String, Object)) = _
            New KeyValuePair(Of String, Object)() {New KeyValuePair(Of String, Object)(keyProperty, id)}
        Dim key As New EntityKey(entitySetFullName, entityKeyValues)
        Return DirectCast(ctx.GetObjectByKey(key), T)
    End Function
