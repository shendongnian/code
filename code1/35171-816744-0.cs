    Private _ExpectedTotalRoyalties As Decimal
    Public Property ExpectedTotalRoyalties() As Decimal
        Get
            Return _ExpectedTotalRoyalties
        End Get
        Protected Set(ByVal value As Decimal)
            If Not _ExpectedTotalRoyalties.Equals(value) Then
                _ExpectedTotalRoyalties = value
                SendPropertyChanged("ExpectedTotalRoyalties")
            End If
        End Set
    End Property
