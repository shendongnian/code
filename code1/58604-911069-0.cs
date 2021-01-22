    Using ts As New System.Transactions.TransactionScope()
      Using sharedConnectionScope As New SubSonic.SharedDbConnectionScope()
    
    ' Do your individual saves here
    
    ' If all OK
          ts.Complete()
    
       End Using
    End Using
