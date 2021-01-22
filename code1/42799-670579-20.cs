    Imports System.Collections.Specialized
    Imports System.ComponentModel
    Imports System.Collections.ObjectModel
    Public Class ObservableRangeCollection(Of T) : Inherits ObservableCollection(Of T) : Implements INotifyCollcetionChanging(Of T)
        ''' <summary>
        ''' Initializes a new instance of the System.Collections.ObjectModel.ObservableCollection(Of T) class.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
        End Sub
        ''' <summary>
        ''' Initializes a new instance of the System.Collections.ObjectModel.ObservableCollection(Of T) class that contains elements copied from the specified collection.
        ''' </summary>
        ''' <param name="collection">collection: The collection from which the elements are copied.</param>
        ''' <exception cref="System.ArgumentNullException">The collection parameter cannot be null.</exception>
        Public Sub New(ByVal collection As IEnumerable(Of T))
            MyBase.New(collection)
        End Sub
        ''' <summary>
        ''' Adds the elements of the specified collection to the end of the ObservableCollection(Of T).
        ''' </summary>
        Public Sub AddRange(ByVal collection As IEnumerable(Of T))
            Dim ce As New NotifyCollectionChangingEventArgs(Of T)(NotifyCollectionChangedAction.Add, collection)
            OnCollectionChanging(ce)
            If ce.Cancel Then Exit Sub
            Dim index = Items.Count - 1
            For Each i In collection
                Items.Add(i)
            Next
            OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collection, index))
        End Sub
        ''' <summary>
        ''' Inserts the collection at specified index.
        ''' </summary>
        Public Sub InsertRange(ByVal index As Integer, ByVal Collection As IEnumerable(Of T))
            Dim ce As New NotifyCollectionChangingEventArgs(Of T)(NotifyCollectionChangedAction.Add, Collection)
            OnCollectionChanging(ce)
            If ce.Cancel Then Exit Sub
            For Each i In Collection
                Items.Insert(index, i)
            Next
            OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
        End Sub
        ''' <summary>
        ''' Removes the first occurence of each item in the specified collection from ObservableCollection(Of T).
        ''' </summary>
        Public Sub RemoveRange(ByVal collection As IEnumerable(Of T))
            Dim ce As New NotifyCollectionChangingEventArgs(Of T)(NotifyCollectionChangedAction.Remove, collection)
            OnCollectionChanging(ce)
            If ce.Cancel Then Exit Sub
            For Each i In collection
                Items.Remove(i)
            Next
            OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
        End Sub
        ''' <summary>
        ''' Clears the current collection and replaces it with the specified item.
        ''' </summary>
        Public Sub Replace(ByVal item As T)
            ReplaceRange(New T() {item})
        End Sub
        ''' <summary>
        ''' Clears the current collection and replaces it with the specified collection.
        ''' </summary>
        Public Sub ReplaceRange(ByVal collection As IEnumerable(Of T))
            Dim ce As New NotifyCollectionChangingEventArgs(Of T)(NotifyCollectionChangedAction.Replace, Items)
            OnCollectionChanging(ce)
            If ce.Cancel Then Exit Sub
            Items.Clear()
            For Each i In collection
                Items.Add(i)
            Next
            OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
        End Sub
        Protected Overrides Sub ClearItems()
            Dim e As New NotifyCollectionChangingEventArgs(Of T)(NotifyCollectionChangedAction.Reset, Items)
            OnCollectionChanging(e)
            If e.Cancel Then Exit Sub
            MyBase.ClearItems()
        End Sub
        Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As T)
            Dim ce As New NotifyCollectionChangingEventArgs(Of T)(NotifyCollectionChangedAction.Add, item)
            OnCollectionChanging(ce)
            If ce.Cancel Then Exit Sub
            MyBase.InsertItem(index, item)
        End Sub
        Protected Overrides Sub MoveItem(ByVal oldIndex As Integer, ByVal newIndex As Integer)
            Dim ce As New NotifyCollectionChangingEventArgs(Of T)()
            OnCollectionChanging(ce)
            If ce.Cancel Then Exit Sub
            MyBase.MoveItem(oldIndex, newIndex)
        End Sub
        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            Dim ce As New NotifyCollectionChangingEventArgs(Of T)(NotifyCollectionChangedAction.Remove, Items(index))
            OnCollectionChanging(ce)
            If ce.Cancel Then Exit Sub
            MyBase.RemoveItem(index)
        End Sub
        Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As T)
            Dim ce As New NotifyCollectionChangingEventArgs(Of T)(NotifyCollectionChangedAction.Replace, Items(index))
            OnCollectionChanging(ce)
            If ce.Cancel Then Exit Sub
            MyBase.SetItem(index, item)
        End Sub
        Protected Overrides Sub OnCollectionChanged(ByVal e As Specialized.NotifyCollectionChangedEventArgs)
            If e.NewItems IsNot Nothing Then
                For Each i As T In e.NewItems
                    If TypeOf i Is INotifyPropertyChanged Then AddHandler DirectCast(i, INotifyPropertyChanged).PropertyChanged, AddressOf Item_PropertyChanged
                Next
            End If
            MyBase.OnCollectionChanged(e)
        End Sub
        Private Sub Item_PropertyChanged(ByVal sender As T, ByVal e As ComponentModel.PropertyChangedEventArgs)
            OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, sender, IndexOf(sender)))
        End Sub
        Public Event CollectionChanging(ByVal sender As Object, ByVal e As NotifyCollectionChangingEventArgs(Of T)) Implements INotifyCollcetionChanging(Of T).CollectionChanging
        Protected Overridable Sub OnCollectionChanging(ByVal e As NotifyCollectionChangingEventArgs(Of T))
            RaiseEvent CollectionChanging(Me, e)
        End Sub
    End Class
    Public Interface INotifyCollcetionChanging(Of T)
        Event CollectionChanging(ByVal sender As Object, ByVal e As NotifyCollectionChangingEventArgs(Of T))
    End Interface
    Public Class NotifyCollectionChangingEventArgs(Of T) : Inherits CancelEventArgs
        Public Sub New()
            m_Action = NotifyCollectionChangedAction.Move
            m_Items = New T() {}
        End Sub
        Public Sub New(ByVal action As NotifyCollectionChangedAction, ByVal item As T)
            m_Action = action
            m_Items = New T() {item}
        End Sub
        Public Sub New(ByVal action As NotifyCollectionChangedAction, ByVal items As IEnumerable(Of T))
            m_Action = action
            m_Items = items
        End Sub
        Private m_Action As NotifyCollectionChangedAction
        Public ReadOnly Property Action() As NotifyCollectionChangedAction
            Get
                Return m_Action
            End Get
        End Property
        Private m_Items As IList
        Public ReadOnly Property Items() As IEnumerable(Of T)
            Get
                Return m_Items
            End Get
        End Property
    End Class
