    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
          ' Reflect on method P:
        Dim mi As MethodInfo = Me.GetType.GetMethod("P")
       ' Iterate all parameters, and call its ParameterType.IsByRef method:
        For Each pi As ParameterInfo In mi.GetParameters
           If **pi.ParameterType.IsByRef** _
           Then Console.WriteLine(pi.Name & " is ByRef") _
           Else Console.WriteLine(pi.Name & " is ByVal")
        Next
    End Sub
