    Sub skDataReceived(ByVal result As IAsyncResult)
        // backup the context here
        Dim syncContext As SynchronizationContext = AsyncOperationManager.SynchronizationContext
        // interact with the UI thread
        CType(My.Application.OpenForms.Item("frmMain"), frmMain).refreshStats(d1, d2)
        // restore context.
        AsyncOperationManager.SynchronizationContext = syncContext
    End Sub
