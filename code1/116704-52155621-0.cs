    Public Shared Function ColorToConsoleColor(cColor As Color) As ConsoleColor
            Dim cc As ConsoleColor
            If Not System.Enum.TryParse(Of ConsoleColor)(cColor.Name, cc) Then
                Dim intensity = If(Color.Gray.GetBrightness() < cColor.GetBrightness(), 8, 0)
                Dim r = If(cColor.R >= &H80, 4, 0)
                Dim g = If(cColor.G >= &H80, 2, 0)
                Dim b = If(cColor.B >= &H80, 1, 0)
    
                cc = CType(intensity + r + g + b, ConsoleColor)
            End If
            Return cc
        End Function
