    Public Interface MPropertySettable
    End Interface
    Public Module PropertySettable
      <Extension()> _
      Public Sub SetValue(Of T)(ByVal self As MPropertySettable, ByVal name As String, ByVal value As T)
        self.GetType().GetProperty(name).SetValue(self, value, Nothing)
      End Sub
    End Module
