    Public Shared Function GetMonthList() As Generic.Dictionary(Of String, String)
        Dim months As New Generic.Dictionary(Of String, String)()
        For m As Int32 = 1 To 12
            months.Add(String.Format("{0:0#}", m), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m))
        Next
        Return months
    End Function
