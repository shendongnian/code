    <Serializable()> Public Class DataGridViewColumnSetting
    Property ColumnNames As List(Of String)
    Property ColumnDisplayIndex As List(Of Integer)
    Property ColumnVisiblility As List(Of Boolean)
    Property ColumnSize As List(Of Integer)
    Public Sub New()
        ColumnDisplayIndex = New List(Of Integer)
        ColumnNames = New List(Of String)
        ColumnSize = New List(Of Integer)
        ColumnVisiblility = New List(Of Boolean)
    End Sub
