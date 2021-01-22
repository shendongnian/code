    ' The declaration part
    Public Structure driveInfo
        Public type As String
        Public size As Long
    End Structure
    Public Structure systemInfo
        Public cPU As String
        Public memory As Long
        Public diskDrives() As driveInfo
        Public purchaseDate As Date
    End Structure
    ' this is the implementation part 
    Dim allSystems(100) As systemInfo
    ReDim allSystems(1).diskDrives(3)
    allSystems(1).diskDrives(0).type = "Floppy"
