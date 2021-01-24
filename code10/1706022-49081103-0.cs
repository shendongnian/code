    Imports System.Data.SqlClient
    Imports System.IO
    Imports Microsoft.VisualBasic.FileIO
    Imports System.Data
    Imports System.Data.Odbc
    Imports System.Data.OleDb
    
    
    Public Class Form1
    
        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    
    
            Dim headers = (From header As DataGridViewColumn In DataGridView1.Columns.Cast(Of DataGridViewColumn)() Select header.HeaderText).ToArray
            Dim rows = From row As DataGridViewRow In DataGridView1.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))
            Dim str As String = ""
            Using sw As New IO.StreamWriter("C:\Users\Excel\Desktop\OrdersTest.csv")
                sw.WriteLine(String.Join(",", headers))
                'sw.WriteLine(String.Join(","))
                For Each r In rows
                    sw.WriteLine(String.Join(",", r))
                Next
                sw.Close()
            End Using
    
        End Sub
    
        Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
            'Dim m_strConnection As String = "server=Excel-PC\SQLEXPRESS;Initial Catalog=Northwind;Trusted_Connection=True;"
    
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString())
            'End Try
    
            'Dim objDataset1 As DataSet()
            'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Dim da As OdbcDataAdapter
            Dim OpenFile As New System.Windows.Forms.OpenFileDialog ' Does something w/ the OpenFileDialog
            Dim strFullPath As String, strFileName As String
            Dim tbFile As New TextBox
            ' Sets some OpenFileDialog box options
            OpenFile.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*" ' Shows only .csv files
            OpenFile.Title = "Browse to file:" ' Title at the top of the dialog box
    
            If OpenFile.ShowDialog() = DialogResult.OK Then ' Makes the open file dialog box show up
                strFullPath = OpenFile.FileName ' Assigns variable
                strFileName = Path.GetFileName(strFullPath)
    
                If OpenFile.FileNames.Length > 0 Then ' Checks to see if they've picked a file
    
                    tbFile.Text = strFullPath ' Puts the filename in the textbox
    
                    ' The connection string for reading into data connection form
                    Dim connStr As String
                    connStr = "Driver={Microsoft Text Driver (*.txt; *.csv)}; Dbq=" + Path.GetDirectoryName(strFullPath) + "; Extensions=csv,txt "
    
                    ' Sets up the data set and gets stuff from .csv file
                    Dim Conn As New OdbcConnection(connStr)
                    Dim ds As DataSet
                    Dim DataAdapter As New OdbcDataAdapter("SELECT * FROM [" + strFileName + "]", Conn)
                    ds = New DataSet
    
                    Try
                        DataAdapter.Fill(ds, strFileName) ' Fills data grid..
                        DataGridView1.DataSource = ds.Tables(strFileName) ' ..according to data source
    
                        ' Catch and display database errors
                    Catch ex As OdbcException
                        Dim odbcError As OdbcError
                        For Each odbcError In ex.Errors
                            MessageBox.Show(ex.Message)
                        Next
                    End Try
    
                    ' Cleanup
                    OpenFile.Dispose()
                    Conn.Dispose()
                    DataAdapter.Dispose()
                    ds.Dispose()
    
                End If
            End If
    
        End Sub
    
        Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
            Dim cnn As SqlConnection
            Dim connectionString As String
            Dim sql As String
    
            connectionString = "data source=Excel-PC\SQLEXPRESS;" &
            "initial catalog=NORTHWND;Trusted_Connection=True"
            cnn = New SqlConnection(connectionString)
            cnn.Open()
            sql = "SELECT * FROM Orders"
            Dim dscmd As New SqlDataAdapter(sql, cnn)
            Dim ds As New DataSet
            dscmd.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            cnn.Close()
    
        End Sub
    
    
        Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
            Dim tblReadCSV As New DataTable()
    
            tblReadCSV.Columns.Add("FName")
            tblReadCSV.Columns.Add("LName")
            tblReadCSV.Columns.Add("Department")
    
            Dim csvParser As New TextFieldParser("C:\Users\Excel\Desktop\Employee.txt")
    
            csvParser.Delimiters = New String() {","}
            csvParser.TrimWhiteSpace = True
            csvParser.ReadLine()
    
            While Not (csvParser.EndOfData = True)
                tblReadCSV.Rows.Add(csvParser.ReadFields())
            End While
    
            Dim con As New SqlConnection("Server=Excel-PC\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;")
            Dim strSql As String = "Insert into Employee(FName,LName,Department) values(@Fname,@Lname,@Department)"
            'Dim con As New SqlConnection(strCon)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSql
            cmd.Connection = con
            cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 50, "FName")
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 50, "LName")
            cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50, "Department")
    
            Dim dAdapter As New SqlDataAdapter()
            dAdapter.InsertCommand = cmd
            Dim result As Integer = dAdapter.Update(tblReadCSV)
    
        End Sub
    
    
    End Class
