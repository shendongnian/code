    	Public Module ControlExtensions
        <System.Runtime.CompilerServices.Extension()> _
        Public Function FindControlByID(ByRef SourceControl As Control, ByRef ControlID As String) As Control
            If Not String.IsNullOrEmpty(ControlID) Then
                Return FindControlHelper(Of Control)(SourceControl.Controls, ControlID)
            Else
                Return Nothing
            End If
        End Function
        Private Function FindControlHelper(Of GenericControlType)(ByVal ConCol As ControlCollection, ByRef ControlID As String) As Control
            Dim RetControl As Control
            For Each Con As Control In ConCol
                If ControlID IsNot Nothing Then
                    If Con.ID = ControlID Then
                        Return Con
                    End If
                Else
                    If TypeOf Con Is GenericControlType Then
                        Return Con
                    End If
                End If
                If Con.HasControls Then
                    If ControlID IsNot Nothing Then
                        RetControl = FindControlByID(Con, ControlID)
                    Else
                        RetControl = FindControlByType(Of GenericControlType)(Con)
                    End If
                    If RetControl IsNot Nothing Then
                        Return RetControl
                    End If
                End If
            Next
            Return Nothing
        End Function
    End Module
