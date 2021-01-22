    Partial Public Class NorthwindCacheServerSyncProvider
        Private Sub ApplyChangeFailedEvent(…) Handles Me.ApplyChangeFailed
            Dim clientChanges As DataTable = e.Conflict.ClientChange
            Dim serverChanges As DataTable = e.Conflict.ServerChange
            ' Code to resolve conflict 
               If (clientChanges.Rows(0)("ModifiedDate") > _
                   serverChanges.Rows(0)("ModifiedDate") Then e.Action =         	          ApplyAction.RetryWithForceWrite 
               End If         
