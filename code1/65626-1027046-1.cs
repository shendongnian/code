     Public Sub AttachDateTimeMouseWheels(ByRef ownerForm As Control)
        Dim myControl As Control        
        For Each myControl In ownerForm.Controls
            If TypeOf myControl Is DateTimePicker Then
                AddHandler myControl.MouseWheel, AddressOf dtpDateTimePicker_MouseWheel
            Else
                If myControl.Controls.Count > 0 Then
                    AttachDateTimeMouseWheels(myControl)
                End If
            End If
        Next
    End Sub
