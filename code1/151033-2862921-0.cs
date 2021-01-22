    Protected Overrides Function GetFormattedValue(ByVal value As Object, ByVal rowIndex As Integer, ByRef cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal valueTypeConverter As System.ComponentModel.TypeConverter, ByVal formattedValueTypeConverter As System.ComponentModel.TypeConverter, ByVal context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object
            Dim strVal As String
    
            strVal = New String(CChar("*"), value.ToString.Length)
    
            Return MyBase.GetFormattedValue(strVal, rowIndex, cellStyle, valueTypeConverter, formattedValueTypeConverter, context)
    
        End Function
        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
    
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
                                            dataGridViewCellStyle)
    
            Dim ctl As PasswordTextBoxEditingControl = _
                CType(DataGridView.EditingControl, PasswordTextBoxEditingControl)
    
            If IsDBNull(Me.Value) Then
                ctl.Text = ""
    
    
            Else
                ctl.Text = CType(Me.Value, String)
                ctl.PasswordChar = "*"
                ctl.Mask = "*"
            End If
    
        End Sub
