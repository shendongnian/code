    '************************************* Module Header **************************************'
    ' Module Name:	MainForm.vb
    ' Project:		VBWinFormMultipleColumnComboBox
    ' Copyright (c) Microsoft Corporation.
    ' 
    ' 
    ' This sample demonstrates how to display multiple columns of data in the dropdown of a ComboBox.
    ' 
    ' This source is subject to the Microsoft Public License.
    ' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
    ' All other rights reserved.
    ' 
    ' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
    ' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
    ' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
    '******************************************************************************************'
    
    Imports System
    Imports System.Collections.Generic
    Imports System.ComponentModel
    Imports System.Data
    Imports System.Drawing
    Imports System.Linq
    Imports System.Text
    Imports System.Windows.Forms
    Imports System.Drawing.Drawing2D
    
    Public Class MainForm
    
        Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dtTest As DataTable = New DataTable()
            dtTest.Columns.Add("ID", GetType(Integer))
            dtTest.Columns.Add("Name", GetType(String))
    
            dtTest.Rows.Add(1, "John")
            dtTest.Rows.Add(2, "Amy")
            dtTest.Rows.Add(3, "Tony")
            dtTest.Rows.Add(4, "Bruce")
            dtTest.Rows.Add(5, "Allen")
    
            ' Bind the ComboBox to the DataTable
            Me.comboBox1.DataSource = dtTest
            Me.comboBox1.DisplayMember = "Name"
            Me.comboBox1.ValueMember = "ID"
    
            ' Enable the owner draw on the ComboBox.
            Me.comboBox1.DrawMode = DrawMode.OwnerDrawFixed
            ' Handle the DrawItem event to draw the items.
        End Sub
    
        Private Sub comboBox1_DrawItem(ByVal sender As System.Object, _
                                       ByVal e As System.Windows.Forms.DrawItemEventArgs) _
                                       Handles comboBox1.DrawItem
            ' Draw the default background
            e.DrawBackground()
    
            ' The ComboBox is bound to a DataTable,
            ' so the items are DataRowView objects.
            Dim drv As DataRowView = CType(comboBox1.Items(e.Index), DataRowView)
    
            ' Retrieve the value of each column.
            Dim id As Integer = drv("ID").ToString()
            Dim name As String = drv("Name").ToString()
    
            ' Get the bounds for the first column
            Dim r1 As Rectangle = e.Bounds
            r1.Width = r1.Width / 2
    
            ' Draw the text on the first column
            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(id, e.Font, sb, r1)
            End Using
    
            ' Draw a line to isolate the columns 
            Using p As Pen = New Pen(Color.Black)
                e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
            End Using
    
            ' Get the bounds for the second column
            Dim r2 As Rectangle = e.Bounds
            r2.X = e.Bounds.Width / 2
            r2.Width = r2.Width / 2
    
            ' Draw the text on the second column
            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(name, e.Font, sb, r2)
            End Using
        End Sub
    End Class
