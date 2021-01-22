    Imports System.Web.UI.WebControls
    Imports System.ComponentModel
    Namespace UI.WebControls
    Public Class GridViewExtended
        Inherits GridView
        Private _footerRow As GridViewRow
        <DefaultValue(False), Category("Appearance"), Description("Include the footer when the table is empty")> _
        Property ShowFooterWhenEmpty As Boolean
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)> _
        Public Overrides ReadOnly Property FooterRow As GridViewRow
            Get
                If (Me._footerRow Is Nothing) Then
                    Me.EnsureChildControls()
                End If
                Return Me._footerRow
            End Get
        End Property
        Protected Overrides Function CreateChildControls(ByVal dataSource As System.Collections.IEnumerable, ByVal dataBinding As Boolean) As Integer
            Dim returnVal As Integer = MyBase.CreateChildControls(dataSource, dataBinding)
            If returnVal = 0 AndAlso Me.ShowFooterWhenEmpty Then
                Dim table As Table = Me.Controls.OfType(Of Table)().First
                Me._footerRow = Me.CreateRow(-1, -1, DataControlRowType.Footer, DataControlRowState.Normal, dataBinding, Nothing, Me.Columns.Cast(Of DataControlField).ToArray, table.Rows, Nothing)
                If Not Me.ShowFooter Then
                    _footerRow.Visible = False
                End If
            End If
            Return returnVal
        End Function
        Private Overloads Function CreateRow(ByVal rowIndex As Integer, ByVal dataSourceIndex As Integer, ByVal rowType As DataControlRowType, ByVal rowState As DataControlRowState, ByVal dataBind As Boolean, ByVal dataItem As Object, ByVal fields As DataControlField(), ByVal rows As TableRowCollection, ByVal pagedDataSource As PagedDataSource) As GridViewRow
            Dim row As GridViewRow = Me.CreateRow(rowIndex, dataSourceIndex, rowType, rowState)
            Dim e As New GridViewRowEventArgs(row)
            If (rowType <> DataControlRowType.Pager) Then
                Me.InitializeRow(row, fields)
            Else
                Me.InitializePager(row, fields.Length, pagedDataSource)
            End If
            If dataBind Then
                row.DataItem = dataItem
            End If
            Me.OnRowCreated(e)
            rows.Add(row)
            If dataBind Then
                row.DataBind()
                Me.OnRowDataBound(e)
                row.DataItem = Nothing
            End If
            Return row
        End Function
    End Class
    End Namespace
