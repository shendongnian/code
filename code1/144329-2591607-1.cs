     Private Shared _UpCommand As RoutedCommand
        Private Shared _DownCommand As RoutedCommand
    
        Public Shared ReadOnly Property UpCommand() As RoutedCommand
            Get
                Return _UpCommand
            End Get
        End Property
    
        Private Shared Sub InitializeCommands()
    
            _UpCommand = New RoutedCommand("UpCommand", GetType(IntegerTextBox))
            CommandManager.RegisterClassCommandBinding(GetType(IntegerTextBox), New CommandBinding(_UpCommand, AddressOf OnUpCommand))
            CommandManager.RegisterClassInputBinding(GetType(IntegerTextBox), New InputBinding(_UpCommand, New KeyGesture(Key.Up)))
    
        End Sub
    
        Private Shared Sub OnUpCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
    
            Dim itb As IntegerTextBox = TryCast(sender, IntegerTextBox)
            If itb Is Nothing Then Return
            itb.OnUp()
    
        End Sub
    
    Protected Overridable Sub OnUp()
    
            Dim caretIndex As Integer = Me.CaretIndex
    
            Me.Value += 1
    
            Me.GetBindingExpression(IntegerTextBox.TextProperty).UpdateSource()
    
            If caretIndex <= Me.Text.Length Then Me.CaretIndex = caretIndex Else Me.CaretIndex = Me.Text.Length
    
        End Sub
