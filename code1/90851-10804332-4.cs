    Public Class OrderDCTyping
        Public Property OrderID As Long = 0
        Public Property OrderTrackingNumber As String = String.Empty
        Public Property OrderShipped As Boolean = False
        Public Property OrderShippedOn As Date = Nothing
        Public Property OrderPaid As Boolean = False
        Public Property OrderPaidOn As Date = Nothing
        Public Property TransactionID As String
    End Class
