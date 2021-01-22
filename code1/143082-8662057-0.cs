    Imports System.Reflection
    Private Sub ResetCloseReason()
      Dim myFieldInfo As FieldInfo
      Dim myType As Type = GetType(Form)
      myFieldInfo = myType.GetField("closeReason", BindingFlags.NonPublic Or _
                        BindingFlags.Instance Or BindingFlags.Public)
      myFieldInfo.SetValue(Me, CloseReason.None)
End Sub
