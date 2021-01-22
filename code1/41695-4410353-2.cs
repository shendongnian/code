    public Base as TextBox, CustomProperty as Integer
    
    Private Sub Init(newTextBox as TextBox)
        Set Base = newTextBox
    End Sub
    
    public Property Get CustomProperty2() As String
        CustomProperty2 = "Something special"
    End Property
