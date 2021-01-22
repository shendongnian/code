    Imports System.Runtime.CompilerServices
    
    Module DoubleExtensions
    
        <Extension()>
        Public Function Truncate(dValue As Double, digits As Integer)
    
            Dim factor As Integer
            factor = Math.Pow(10, digits)
    
            Return Math.Truncate(dValue * factor) / factor
    
        End Function
    End Module
