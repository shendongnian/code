    Public Property Get LengthInches() As Double
      LengthInches = LengthMetres * 39
    End Property
    
    Public Property Let LengthInches(Value As Double)
      LengthMetres = Value / 39
    End Property
