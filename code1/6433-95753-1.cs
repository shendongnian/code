    Public Sub Run(ByVal strToProcess As String) Implements IPerfStub.Run
        Dim genList As New ArrayList
    
        For Each ch As Char In strToProcess.ToCharArray
            genList.Add(ch)
        Next
    
        Dim dummy As New System.Text.StringBuilder()
        For i As Integer = 0 To genList.Count - 1
            dummy.Append(genList(i))
        Next
    
    End Sub
    
     Public Sub Run(ByVal strToProcess As String) Implements IPerfStub.Run
         Dim genList As New List(Of Char)
     
         For Each ch As Char In strToProcess.ToCharArray
             genList.Add(ch)
         Next
     
         Dim dummy As New System.Text.StringBuilder()
         For i As Integer = 0 To genList.Count - 1
             dummy.Append(genList(i))
         Next
     End Sub
