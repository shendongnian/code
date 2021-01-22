        ''' <summary>
        ''' Returns enumeration as a sortable list.
        ''' </summary>
        ''' <param name="t">GetType(some enumeration)</param>
        Public Shared Function GetEnumAsList(ByVal t As Type) As SortedList(Of String, Integer)
            If Not t.IsEnum Then
                Throw New ArgumentException("Type is not an enumeration.")
            End If
            Dim items As New SortedList(Of String, Integer)
            Dim enumValues As Integer() = [Enum].GetValues(t)
            Dim enumNames As String() = [Enum].GetNames(t)
            For i As Integer = 0 To enumValues.GetUpperBound(0)
                items.Add(enumNames(i), enumValues(i))
            Next
            Return items
        End Function
