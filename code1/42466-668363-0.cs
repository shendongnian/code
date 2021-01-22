    Public Sub BindControl(ctl As ITextControl, ByRef objectProperty As String)
        objectProperty = ITextControl.Text
    End Sub
    Public Sub BindControl(ctl As ITextControl, ByRef objectProperty As Integer)
        Integer.TryParse(TextControl.Text, objectProperty)
    End Sub
    ..
