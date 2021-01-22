    <TestMethod()> _
    Public Sub MainTest()
        Dim cut As New Triggerific
        cut.AddTrigger()
        Assert.IsNotNull(GetEventHandler(cut, "Trigger"))
    End Sub
    Private Shared Function GetEventHandler(ByVal classInstance As Object, ByVal eventName As String) As EventHandler
        Dim classType As Type = classInstance.[GetType]()
        Dim eventField As FieldInfo = classType.GetField(eventName, BindingFlags.GetField Or BindingFlags.NonPublic Or BindingFlags.Instance)
        Dim eventDelegate As EventHandler = DirectCast(eventField.GetValue(classInstance), EventHandler)
        ' eventDelegate will be null if no listeners are attached to the event
        If eventDelegate Is Nothing Then
            Return Nothing
        End If
        Return eventDelegate
    End Function
