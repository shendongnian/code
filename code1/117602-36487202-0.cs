    Public Class DynamicTuple
    Public Shared Function CreateTupleAtRuntime(ParamArray types As Type()) As Object
        If types Is Nothing Then Throw New ArgumentNullException(NameOf(types))
        If types.Length < 1 Then Throw New ArgumentNullException(NameOf(types))
        If types.Contains(Nothing) Then Throw New ArgumentNullException(NameOf(types))
        Return CreateTupleAtRuntime(types, types.Select(Function(typ) typ.GetDefault).ToArray)
    End Function
    Public Shared Function CreateTupleAtRuntime(types As Type(), values As Object()) As Object
        If types Is Nothing Then Throw New ArgumentNullException(NameOf(types))
        If values Is Nothing Then Throw New ArgumentNullException(NameOf(values))
        If types.Length < 1 Then Throw New ArgumentNullException(NameOf(types))
        If values.Length < 1 Then Throw New ArgumentNullException(NameOf(values))
        If types.Length <> values.Length Then Throw New ArgumentException("Both the type and the value array must be of equal length.")
        Dim tupleNested As Object = Nothing
        If types.Length > 7 Then
            tupleNested = CreateTupleAtRuntime(types.Skip(7).ToArray, values.Skip(7).ToArray)
            types(7) = tupleNested.GetType
            ReDim Preserve types(0 To 7)
            ReDim Preserve values(0 To 7)
        End If
        Dim typeCount As Integer = types.Length
        Dim tupleTypeName As String = GetType(Tuple).AssemblyQualifiedName.Replace("Tuple,", "Tuple`" & typeCount & ",")
        Dim genericTupleType = Type.[GetType](tupleTypeName)
        Dim constructedTupleType = genericTupleType.MakeGenericType(types)
        Dim args = types.Select(Function(typ, index)
                                    If index = 7 Then
                                        Return tupleNested
                                    Else
                                        Return values(index)
                                    End If
                                End Function)
        Try
            Return constructedTupleType.GetConstructors().First.Invoke(args.ToArray)
        Catch ex As Exception
            Throw New ArgumentException("Could not map the supplied values to the supplied types.", ex)
        End Try
    End Function
    Public Shared Function CreateFromIDataRecord(dataRecord As IDataRecord) As Object
        If dataRecord Is Nothing Then Throw New ArgumentNullException(NameOf(dataRecord))
        If dataRecord.FieldCount < 1 Then Throw New InvalidOperationException("DataRecord must have at least one field.")
        Dim fieldCount = dataRecord.FieldCount
        Dim types(0 To fieldCount - 1) As Type
        Dim values(0 To fieldCount - 1) As Object
        For I = 0 To fieldCount - 1
            types(I) = dataRecord.GetFieldType(I)
        Next
        dataRecord.GetValues(values)
        Return CreateTupleAtRuntime(types, values)
    End Function
    End Class
