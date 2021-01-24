        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim types As Type() = myAssembly.GetTypes()
        For Each t As Type In types
            If UCase(t.BaseType.ToString) = "SYSTEM.WINDOWS.FORMS.FORM" Then
                'MessageBox.Show(t.Name)
                ListBox1.Items.Add(t.Name)
            End If
        Next
    End Sub
     
