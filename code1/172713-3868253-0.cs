    Public Function GetDateTimeFromServer() As DateTime
        Using context As New NorthwindEntities()
            Dim dateQry As IQueryable(Of DateTime) = From bogus In context.Products_
                Select DateTime.Now
            Dim result As DateTime = dateQry.First()
            Return result
        End Using
    End Function
