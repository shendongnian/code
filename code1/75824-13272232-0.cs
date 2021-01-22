    ''' <summary>
    ''' Import the properties that match by name in the source to the target.</summary>
    ''' <param name="target">Object to import the properties into.</param>
    ''' <param name="source">Object to import the properties from.</param>
    ''' <returns>
    ''' True, if the import can without exception; otherwise, False.</returns>
    <System.Runtime.CompilerServices.Extension()>
    Public Function Import(target As Object, source As Object) As Boolean
        Dim targetProperties As IEnumerable(Of Tuple(Of Reflection.PropertyInfo, Reflection.MethodInfo)) =
            (From aPropertyInfo In source.GetType().GetProperties(Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
             Let propertyAccessors = aPropertyInfo.GetAccessors(True)
             Let propertyMethods = aPropertyInfo.PropertyType.GetMethods()
             Let addMethod = (From aMethodInfo In propertyMethods
                              Where aMethodInfo.Name = "Add" AndAlso aMethodInfo.GetParameters().Length = 1
                              Select aMethodInfo).FirstOrDefault()
             Where aPropertyInfo.CanRead AndAlso aPropertyInfo.GetIndexParameters().Length = 0 _
              AndAlso (aPropertyInfo.CanWrite OrElse addMethod IsNot Nothing) _
              AndAlso (From aMethodInfo In propertyAccessors
                       Where aMethodInfo.IsPrivate _
                        OrElse (aMethodInfo.Name.StartsWith("get_") OrElse aMethodInfo.Name.StartsWith("set_"))).FirstOrDefault() IsNot Nothing
             Select New Tuple(Of Reflection.PropertyInfo, Reflection.MethodInfo)(aPropertyInfo, addMethod))
        ' No properties to import into.
        If targetProperties.Count() = 0 Then Return True
        Dim sourceProperties As IEnumerable(Of Tuple(Of Reflection.PropertyInfo, Reflection.MethodInfo)) =
            (From aPropertyInfo In source.GetType().GetProperties(Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
             Let propertyAccessors = aPropertyInfo.GetAccessors(True)
             Let propertyMethods = aPropertyInfo.PropertyType.GetMethods()
             Let addMethod = (From aMethodInfo In propertyMethods
                              Where aMethodInfo.Name = "Add" AndAlso aMethodInfo.GetParameters().Length = 1
                              Select aMethodInfo).FirstOrDefault()
             Where aPropertyInfo.CanRead AndAlso aPropertyInfo.GetIndexParameters().Length = 0 _
              AndAlso (aPropertyInfo.CanWrite OrElse addMethod IsNot Nothing) _
              AndAlso (From aMethodInfo In propertyAccessors
                       Where aMethodInfo.IsPrivate _
                        OrElse (aMethodInfo.Name.StartsWith("get_") OrElse aMethodInfo.Name.StartsWith("set_"))).FirstOrDefault() IsNot Nothing
             Select New Tuple(Of Reflection.PropertyInfo, Reflection.MethodInfo)(aPropertyInfo, addMethod))
        ' No properties to import.
        If sourceProperties.Count() = 0 Then Return True
        Try
            Dim currentPropertyInfo As Tuple(Of Reflection.PropertyInfo, Reflection.MethodInfo)
            Dim matchingPropertyInfo As Tuple(Of Reflection.PropertyInfo, Reflection.MethodInfo)
            ' Copy the properties from the source to the target, that match by name.
            For Each currentPropertyInfo In sourceProperties
                matchingPropertyInfo = (From aPropertyInfo In targetProperties
                                        Where aPropertyInfo.Item1.Name = currentPropertyInfo.Item1.Name).FirstOrDefault()
                ' If a property matches in the target, then copy the value from the source to the target.
                If matchingPropertyInfo IsNot Nothing Then
                    If matchingPropertyInfo.Item1.CanWrite Then
                        matchingPropertyInfo.Item1.SetValue(target, matchingPropertyInfo.Item1.GetValue(source, Nothing), Nothing)
                    ElseIf matchingPropertyInfo.Item2 IsNot Nothing Then
                        Dim isEnumerable As IEnumerable = TryCast(currentPropertyInfo.Item1.GetValue(source, Nothing), IEnumerable)
                        If isEnumerable Is Nothing Then Continue For
                        ' Invoke the Add method for each object in this property collection.
                        For Each currentObject As Object In isEnumerable
                            matchingPropertyInfo.Item2.Invoke(matchingPropertyInfo.Item1.GetValue(target, Nothing), New Object() {currentObject})
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
