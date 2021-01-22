    Imports System.Collections.Generic
    Imports System.Collections.ObjectModel
    Imports System.ComponentModel
    Imports System.Linq
    Imports System.Data.Linq
    
    Public Class ObservableEntityCollection(Of T As {Class})
        Inherits ObservableCollection(Of T)
    
        Private _Table As Table(Of T)
    
        Public Sub New(ByVal Context As DataContext)
            Me._Table = Context.GetTable(Of T)()
        End Sub
    
        Public Sub New(ByVal Context As DataContext, ByVal items As IEnumerable(Of T))
            MyBase.New(items)
            Me._Table = Context.GetTable(Of T)()
        End Sub
    
        Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As T)
            _Table.InsertOnSubmit(item)
            MyBase.InsertItem(index, item)
        End Sub
    
        Public Shadows Sub Add(ByVal item As T)
            _Table.InsertOnSubmit(item)
            MyBase.Add(item)
        End Sub
    
        Public Shadows Sub Remove(ByVal item As T)
            If MyBase.Remove(item) Then
                _Table.DeleteOnSubmit(item)
            End If
            Dim deletable As IDeletableEntity = TryCast(item, IDeletableEntity)
            If deletable IsNot Nothing Then deletable.OnDelete()
        End Sub
    
        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            Dim Item As T = Me(index)
            _Table.DeleteOnSubmit(Item)
            MyBase.RemoveItem(index)
        End Sub
    
    End Class
    
    
    Public Interface IDeletableEntity
    
        Sub OnDelete()
    
    End Interface
