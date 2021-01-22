    Imports System
    Imports System.Reflection
    
    Public Module ShowCounts
    
        Sub Main()
            Dim domain As AppDomain = AppDomain.CurrentDomain
    
            For Each assembly As Assembly in domain.GetAssemblies
    
                Console.WriteLine("{0}: {1}", _
                                  assembly.GetName.Name, _
                                  assembly.GetExportedTypes.Length)
    
            Next
        End Sub
    
    End Module
