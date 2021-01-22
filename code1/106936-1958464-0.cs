    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If TypeOf e.Control Is ComboBox Then
            DirectCast(e.Control, ComboBox).DrawMode = DrawMode.OwnerDrawFixed
            Try
                RemoveHandler DirectCast(e.Control, ComboBox).DrawItem, AddressOf combobox1_DrawItem
            Catch ex As Exception
            End Try
            AddHandler DirectCast(e.Control, ComboBox).DrawItem, AddressOf combobox1_DrawItem
        End If
    End Sub
    Private Sub combobox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim g As Graphics = e.Graphics
        Dim s As String
        Dim br As Brush = SystemBrushes.WindowText
        Dim brBack As Brush
        Dim rDraw As Rectangle
        Dim bSelected As Boolean = CBool(e.State And DrawItemState.Selected)
        Dim bValue As Boolean = CBool(e.State And DrawItemState.ComboBoxEdit)
        rDraw = e.Bounds
        rDraw.Inflate(-1, -1)
        If bSelected And Not bValue Then
            brBack = Brushes.LightBlue
            g.FillRectangle(Brushes.LightBlue, rDraw)
            g.DrawRectangle(Pens.Blue, rDraw)
        Else
            brBack = Brushes.White
            g.FillRectangle(brBack, e.Bounds)
        End If
        br = Nothing
        brBack = Nothing
        rDraw = Nothing
        Try
            s = DirectCast(sender, ComboBox).Items.Item(e.Index).ToString
        Catch
            s = ""
        End Try
        Dim x, y As Integer
        x = e.Bounds.Left + 25
        y = e.Bounds.Top + 1
        Dim c As Color
        Dim b As SolidBrush
        c = Color.FromName(s)
        b = New SolidBrush(c)
        g.FillRectangle(b, x - 20, y + 2, 10, 10)
        g.DrawString(s, DataGridView1.Font, Brushes.Black, x, y)
    End Sub
