    Public Shared Function SafeCommitRollback(ByVal Trans As SqlClient.SqlTransaction, Optional ByVal Action As TROperation = TROperation.Commit, Optional ByVal QuietMode As Boolean = False) As Boolean
        SafeCommitRollback = False
    Dim TryRollback As Boolean = False
    Dim ConnLost As Boolean = False
    Dim msgErr As String = ""
    If Action = TROperation.Commit Then
        Try
            Trans.Commit()
            SafeCommitRollback = True
        Catch ex As SqlClient.SqlException When ex.Class = 20 OrElse (ex.Class = 11 And ex.Number = -2)
            ConnLost = True
        Catch ex As System.InvalidOperationException When ex.Source = "System.Data" 'AndAlso ex.Message.StartsWith("Timeout expired.")
            ConnLost = True
        Catch ex As Exception
            TryRollback = True
            msgErr &= clsErrorHandling.ParseException(ex, True)
        End Try
        If ConnLost Then
            Try
                Trans.Commit()
                SafeCommitRollback = True
            Catch ex2 As Exception
                TryRollback = True
                msgErr &= clsErrorHandling.ParseException(ex2, True)
            End Try
        End If
    Else
        TryRollback = True
    End If
    If TryRollback Then
        Try
            Trans.Rollback()
            If Action = TROperation.Rollback Then SafeCommitRollback = True
        Catch ex3 As Exception
            msgErr &= clsErrorHandling.ParseException(ex3)
        End Try
    End If
        If Not QuietMode AndAlso msgErr.Trim <> "" Then clsMessageBox.ShowError(msgErr)
    End Function
