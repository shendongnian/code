    Imports System.Globalization
    
    Public Class Form1
    
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim table As New DataTable
    
            With table.Columns
                .Add("ID", GetType(Integer)).AutoIncrement = True
                .Add("Name", GetType(String))
                .Add("Date", GetType(Date))
            End With
    
            With table.Rows
                .Add(1, "Peter", #1/1/2000#)
                .Add(2, "Paul", #6/19/1969#)
                .Add(3, "Peter", Date.Today)
            End With
    
            DataGridView1.DataSource = table
    
            'Use the display format by default.
            DataGridView1.Columns(2).DefaultCellStyle.Format = "dd.MM.yyyy"
        End Sub
    
        Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
            If DataGridView1.CurrentCellAddress.X = 2 Then
                'Display the date in the editing format.
                Dim cellValue = DataGridView1.CurrentCell.Value
                Dim text = If(cellValue Is DBNull.Value, String.Empty, CDate(cellValue).ToString("ddMMyy"))
    
                e.Control.Text = text
            End If
        End Sub
    
        Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
            If e.ColumnIndex = 2 AndAlso DataGridView1.EditingControl IsNot Nothing Then
                Dim value As Date
    
                'Validate the input using the editing format and the display format.
                e.Cancel = Not Date.TryParseExact(CStr(e.FormattedValue),
                                                  {"ddMMyy", "dd.MM.yyyy"},
                                                  Nothing,
                                                  DateTimeStyles.None,
                                                  value)
    
                If Not e.Cancel Then
                    'Ensure data is displayed using the display format.
                    DataGridView1.EditingControl.Text = value.ToString("dd.MM.yyyy")
                End If
            End If
        End Sub
    
    End Class
