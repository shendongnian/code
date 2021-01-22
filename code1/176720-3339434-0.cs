    Public Class Form1
        Private bSelectMode As Boolean = False
    
        Private Sub Form1_KeyUpOrDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, Me.KeyUp
            bSelectMode = e.Control OrElse e.Shift
        End Sub
    
        Private Sub ListBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseMove
            If bSelectMode AndAlso e.Button <> Windows.Forms.MouseButtons.None Then
                Dim selectedindex = ListBox1.IndexFromPoint(e.Location)
    
                If selectedindex <> -1 Then
                    ListBox1.SelectedItems.Add(ListBox1.Items(selectedindex))
                End If
            End If
        End Sub
    End Class
