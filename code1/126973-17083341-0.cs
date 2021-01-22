    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        ' some code        
        '
        BindingNavigatorSaveItem.Enabled = False
        For Each tabctl As Control In Me.TabControl1.Controls
            For Each ctl As Control In tabctl.Controls
                Try
                    If ctl.GetType Is GetType(TextBox) Then
                        AddHandler DirectCast(ctl, TextBox).TextChanged, AddressOf GenDataChanged
                    ElseIf ctl.GetType Is GetType(NumericUpDown) Then
                        AddHandler DirectCast(ctl, NumericUpDown).ValueChanged, AddressOf GenDataChanged
                    ElseIf ctl.GetType Is GetType(ComboBox) Then
                        AddHandler DirectCast(ctl, ComboBox).SelectedValueChanged, AddressOf GenDataChanged
                    ElseIf ctl.GetType Is GetType(CheckBox) Then
                        AddHandler DirectCast(ctl, CheckBox).CheckStateChanged, AddressOf GenDataChanged
                    End If
                Catch ex As Exception
                End Try
            Next
        Next
    End Sub
    Private Sub GenDataChanged(sender As System.Object, e As System.EventArgs)
        BindingNavigatorSaveItem.Enabled = True
    End Sub
