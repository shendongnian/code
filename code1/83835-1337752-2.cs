    Public event SomeEvent as EventHandler(of SomeEventArg)
    Public Sub SomeMethod()
        // Note that SomeEvent's MulticastDelegate is accessed by appending
        // another "Event" to the end, this sample is redundant but accurate.
        // If the event was named ListChanged then it would be ListChangedEvent
        dim invocationList = SomeEventEvent.GetInvocationList()
    End Sub
