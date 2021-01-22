    Public Function GetCurrentOrders() As IEnumerable(Of OrderDCTyping)
        Try
            Using db As New DataAccess
                With db
                    .QueryType = CmdType.StoredProcedure
                    .Query = "[Desktop].[CurrentOrders]"
                    Using _Results = .GetResults()
                        If _Results IsNot Nothing Then
                            _Qry = (From row In _Results.Cast(Of DbDataRecord)()
                                        Select New OrderDCTyping() With {
                                            .OrderID = Common.IsNull(Of Long)(row, 0, 0),
                                            .OrderTrackingNumber = Common.IsNull(Of String)(row, 1, String.Empty),
                                            .OrderShipped = Common.IsNull(Of Boolean)(row, 2, False),
                                            .OrderShippedOn = Common.IsNull(Of Date)(row, 3, Nothing),
                                            .OrderPaid = Common.IsNull(Of Boolean)(row, 4, False),
                                            .OrderPaidOn = Common.IsNull(Of Date)(row, 5, Nothing),
                                            .TransactionID = Common.IsNull(Of String)(row, 6, String.Empty)
                                        }).ToList()
                        Else
                            _Qry = Nothing
                        End If
                    End Using
                    Return _Qry
                End With
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
