    Public Function GoToPoint(ByVal start As TextPointer, ByVal x As Integer) As TextPointer
        Dim out As TextPointer = start
        Dim i As Integer = 0
        Do While i < x
            If out.GetPointerContext(LogicalDirection.Backward) = TextPointerContext.Text Or _
                 out.GetPointerContext(LogicalDirection.Backward) = TextPointerContext.None Then
                i += 1
            End If
            If out.GetPositionAtOffset(1, LogicalDirection.Forward) Is Nothing Then
                Return out
            Else
                out = out.GetPositionAtOffset(1, LogicalDirection.Forward)
            End If
    
    
        Loop
        Return out
    End Function
