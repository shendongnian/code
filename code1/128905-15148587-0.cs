        Imports System.Reflection
        Public Sub ResizeDescriptionArea(grid As PropertyGrid, lines As Integer)
            Try
                Dim info = grid.[GetType]().GetProperty("Controls")
                Dim collection = DirectCast(info.GetValue(grid, Nothing), Control.ControlCollection)
                For Each control As Object In collection
                    Dim type = control.[GetType]()
                    If "DocComment" = type.Name Then
                        Const Flags As BindingFlags = BindingFlags.Instance Or BindingFlags.NonPublic
                        Dim field = type.BaseType.GetField("userSized", Flags)
                        field.SetValue(control, True)
                        info = type.GetProperty("Lines")
                        info.SetValue(control, lines, Nothing)
                        grid.HelpVisible = True
                        Exit For
                    End If
                Next
            Catch ex As Exception
                Trace.WriteLine(ex)
            End Try
        End Sub
