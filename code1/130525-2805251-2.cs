    Public Interface ICountry
      ReadOnly Property Info() As ICountryInfo
    
      Public Interface ICountryInfo
        ReadOnly Property Population() As Integer
        ReadOnly Property Note() As String
      End Interface
    End Interface
