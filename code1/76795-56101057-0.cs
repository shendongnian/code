    Public Class Form1
    
    Private Sub btnSortListView_Click(sender As Object, e As EventArgs) Handles btnSortListView.Click
            If btnSortListView.Text = "Sort Ascending" Then
                
                ListViewGar.ListViewItemSorter = New IntegerComparer(1)
                ListViewGar.Sort()
    
                btnSortListView.Text = "Not Sort"
    
            Else
                ListViewGar.ListViewItemSorter = New IntegerComparer(0)
                btnSortListView.Text = "Sort Ascending"
            End If
    
        End Sub
    End Class
   
     Public Class IntegerComparer
        Implements System.Collections.IComparer
    
        Private _colIndex As Integer
    
        Public Sub New(ByVal colIndex As Integer)
            MyBase.New
            Me._colIndex = colIndex
        End Sub
    
        'Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer
        '    Dim nx As Integer = Integer.Parse(CType(x, ListViewItem).SubItems(Me._colIndex).Text)
        '    Dim ny As Integer = Integer.Parse(CType(y, ListViewItem).SubItems(Me._colIndex).Text)
        '    Return nx.CompareTo(ny)
        'End Function
    
        Private Function IComparer_Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim nx As Integer = Integer.Parse(CType(x, ListViewItem).SubItems(Me._colIndex).Text)
            Dim ny As Integer = Integer.Parse(CType(y,ListViewItem).SubItems(Me._colIndex).Text)
    
            Dim colIndPlus As Integer = Me._colIndex
            Do While nx.CompareTo(ny) = 0
                colIndPlus = colIndPlus + 1
                nx = Integer.Parse(CType(x, ListViewItem).SubItems(colIndPlus).Text)
                ny = Integer.Parse(CType(y, ListViewItem).SubItems(colIndPlus).Text)
            Loop
    
            Return nx.CompareTo(ny)
    
        End Function
    End Class
    
