    Imports System.Collections
    ''' <summary>
    ''' This class is an implementation of the 'IComparer' interface.
    ''' </summary>
    Public Class ListViewColumnSorter
        Implements IComparer
        ''' <summary>
        ''' Specifies the column to be sorted
        ''' </summary>
        Private ColumnToSort As Integer
        ''' <summary>
        ''' Specifies the secondary column to be sorted
        ''' </summary>
        Private SecondaryColumnToSort As Integer = -1
        ''' <summary>
        ''' Specifies the order in which to sort (i.e. 'Ascending').
        ''' </summary>
        Private OrderOfSort As SortOrder
        ''' <summary>
        ''' Class constructor. Initializes various elements
        ''' </summary>
        Public Sub New(ByVal column_number As Integer, ByVal sort_order As SortOrder)
            ColumnToSort = column_number
            OrderOfSort = sort_order
        End Sub
        ''' <summary>
        ''' Class constructor. Initializes various elements
        ''' </summary>
        Public Sub New(ByVal column_number As Integer, ByVal sort_order As SortOrder, ByVal secondary_column_number As Integer)
            ColumnToSort = column_number
            SecondaryColumnToSort = secondary_column_number
            OrderOfSort = sort_order
        End Sub
        ''' <summary>
        ''' This method is inherited from the IComparer interface. It compares the two objects passed and support secondary column comparison
        ''' </summary>
        ''' <param name="x">First object to be compared</param>
        ''' <param name="y">Second object to be compared</param>
        ''' <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim compareResult As Integer
            Dim listviewX As ListViewItem, listviewY As ListViewItem
            ' Cast the objects to be compared to ListViewItem objects
            listviewX = DirectCast(x, ListViewItem)
            listviewY = DirectCast(y, ListViewItem)
            ' Compare the two items
            Dim x1 As Object = listviewX.SubItems(ColumnToSort)
            Dim y1 As Object = listviewY.SubItems(ColumnToSort)
            ' Use .tag for comparison if not empty
            If (x1.Tag IsNot vbNullString) And (y1.Tag IsNot vbNullString) Then
                compareResult = ObjectComparer(x1.Tag, y1.Tag)
            Else
                compareResult = ObjectComparer(x1.Text, y1.Text)
            End If
            'require secondary column compare?
            If (compareResult = 0 And SecondaryColumnToSort >= 0 And SecondaryColumnToSort <> ColumnToSort) Then
                ' Compare the two items
                Dim x2 As Object = listviewX.SubItems(SecondaryColumnToSort)
                Dim y2 As Object = listviewY.SubItems(SecondaryColumnToSort)
                ' Use .tag for comparison if not empty
                If (x2.Tag IsNot vbNullString) And (y2.Tag IsNot vbNullString) Then
                    compareResult = ObjectComparer(x2.Tag, y2.Tag)
                Else
                    compareResult = ObjectComparer(x2.Text, y2.Text)
                End If
            End If
            ' Calculate correct return value based on object comparison
            If OrderOfSort = SortOrder.Ascending Then
                ' Ascending sort is selected, return normal result of compare operation
                Return compareResult
            ElseIf OrderOfSort = SortOrder.Descending Then
                ' Descending sort is selected, return negative result of compare operation
                Return (-compareResult)
            Else
                ' Return '0' to indicate they are equal
                Return 0
            End If
        End Function
        ''' <summary>
        ''' This method compares the two objects passed. Object supported are numeric, dates and string
        ''' </summary>
        ''' <param name="x">First object to be compared</param>
        ''' <param name="y">Second object to be compared</param>
        ''' <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        Private Function ObjectComparer(x As Object, y As Object) As Integer
            Dim compareResult As Integer
            If IsNumeric(x) And IsNumeric(y) Then 'comparing numbers
                compareResult = Val(x).CompareTo(Val(y))
            ElseIf IsDate(x) And IsDate(y) Then 'comparing dates
                compareResult = DateTime.Parse(x).CompareTo(DateTime.Parse(y))
            Else 'comparing string
                Dim ObjectCompare As New CaseInsensitiveComparer
                compareResult = ObjectCompare.Compare(x.ToString, y.ToString)
            End If
            Return compareResult
        End Function
    End Class
