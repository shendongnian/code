    Public Class DataGridViewUtil
        Private dgv As DataGridView
        Private sizeColumnModeBackup(-1) As DataGridViewAutoSizeColumnMode
    
        Public Sub New(dgv As DataGridView)
            Me.dgv = dgv
        End Sub
    
        ''' <summary>
        ''' Prepare datagridview before we do the row hidding to speedup it
        ''' </summary>
        ''' <remarks>We use a method based on reseting the AutoSizeColumnMode 
        '''  property to None, therefore it will be necessary to call
        '''  HidingRowsSpeederAfer() when we finish hiding rows</remarks>
        Public Sub HidingRowsSpeederBefore()
            ReDim sizeColumnModeBackup(dgv.Columns.Count)
            For Each col As DataGridViewColumn In dgv.Columns
                sizeColumnModeBackup(col.Index) = col.AutoSizeMode
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Next
        End Sub
        ''' <summary>
        ''' Restore DataGridView state changed when HidingRowsSpeederBefore() 
        '''  was called
        ''' </summary>
        ''' <remarks>This procedure must be called after the row hidding has been
        '''   done and requires a previous call to HidingRowsSpeederBefore()</remarks>
        Public Sub HidingRowsSpeederAfter()
            If dgv Is Nothing Then
                Throw New NullReferenceException("The assigned datagridview is null")
            End If
            If sizeColumnModeBackup.Length < dgv.Columns.Count Then
                Throw New Exception("Mismatch on internal SizeColumnMode array, " &
                        "maybe you forgot to call HidingRowsSpeederBefore()")
            End If
            For Each col As DataGridViewColumn In dgv.Columns
                col.AutoSizeMode = sizeColumnModeBackup(col.Index)
            Next
        End Sub
    End Class
