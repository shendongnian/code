    Imports Microsoft.Office.Interop
    
    Public Class Form1
    
        Dim Ex_Ap As Excel.Application
        Dim Ex_Wb As Excel.Workbook
        Dim Ex_Ws As Excel.Worksheet
    
        Function Excel_Color_Get(ByVal i As Int32) As Color
            Static c As Color
            c = Color.FromArgb(i)
            Return Color.FromArgb(c.B, c.G, c.R)
        End Function
    
        Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
            Ex_Ap = New Excel.Application
            Ex_Ap.Visible = True
            Ex_Wb = Ex_Ap.Workbooks.Add
            Ex_Ws = Ex_Wb.Worksheets(1)
            Ex_Ws.Cells(7, 6).Value = "???"
            Ex_Ws.Cells(7, 6).interior.color = Color.Pink
        End Sub
    
        Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
            Try
                TextBox1.BackColor = Excel_Color_Get(Ex_Ws.Cells(7, 6).interior.color)
            Catch ex As Exception
                TextBox1.Text = ex.ToString
            End Try
        End Sub
    
    End Class
