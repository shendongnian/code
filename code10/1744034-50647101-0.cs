    Using Client As New FooServiceClient, Scope As New OperationContextScope(Client.InnerChannel)
        Dim Header As New MessageHeader(Of String)(Thread.CurrentPrincipal.Identity.Name)
        OperationContext.Current.OutgoingMessageHeaders.Add(Header.GetUntypedHeader("String", "System"))
        Return await client.Test();
    End Using
