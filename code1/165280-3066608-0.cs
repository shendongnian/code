    Option Strict Off
    
    Imports System
    Imports System.Console
    Imports Microsoft.Office.Interop
    
    Public Class AreThereHiddenColumnsInExcelWorkSheet
    
        Public Shared Sub Execute()
    
            Dim excel = New Excel.Application
    
            excel.Visible = True
            excel.Workbooks.Add()
            excel.Columns("C:C").Select()
            excel.Selection.EntireColumn.Hidden = True
    
            Dim columns = excel.Columns
            Dim hasHiddenColumns As Boolean
    
            For Each column In columns
                If column.Hidden Then
                    hasHiddenColumns = True
                    Exit For
                End If
            Next
    
            WriteLine("excel.Columns.Hidden = " + hasHiddenColumns.ToString())
    
        End Sub
    
    End Class
