    Private Function AssemblyLoaded(ByVal assemblyFile As String) As Assembly
        For Each asmb As Assembly In AppDomain.CurrentDomain.GetAssemblies
            If TypeOf asmb Is System.Reflection.Emit.AssemblyBuilder Then Continue For
            If System.IO.Path.GetFileName(asmb.Location) = assemblyFile Then Return asmb
        Next
        Return Nothing
    End Function
