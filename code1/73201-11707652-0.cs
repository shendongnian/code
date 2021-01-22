    Dim PrimaryRDOSession As New Redemption.RDOSession()
    PrimaryRDOSession.Login([...])
    Dim WorkerThread as New System.Threading.Thread(AddressOf ThreadProc)
    WorkerThread.Start(PrimaryRDOSession.MAPIOBJECT)
    Sub ThreadProc(ByVal param as Object)
        Dim ThdRDOSession As New Redemption.RDOSession()
        ThdRDOSession.MAPIOBJECT = param
        ' do other stuff
    End Sub
