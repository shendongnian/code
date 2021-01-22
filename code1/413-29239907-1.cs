    Public Function CloneObject(ByVal src As Object) As Object
        Dim result As Object = Nothing
        Dim cloneable As ICloneable
        Try
            cloneable = TryCast(src, ICloneable)
            If cloneable IsNot Nothing Then
                result = cloneable.Clone()
            Else
                result = Activator.CreateInstance(src.GetType())
                CopySimpleProperties(src, result, Nothing, "clone")
            End If
        Catch ex As Exception
            Trace.WriteLine("!!! CloneObject(): " & ex.Message)
        End Try
        Return result
    End Function
