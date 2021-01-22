    Public Property Duration As TimeSpan
    
    <DataMember(Name:="Duration")>
    Private Property DurationString As String
        Get
            Return Duration.ToString
        End Get
        Set(value As String)
            Duration = TimeSpan.Parse(value)
        End Set
    End Property
       
