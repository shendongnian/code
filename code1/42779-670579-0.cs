    ''' <summary>
    ''' Adds the elements of the specified collection to the end of the ObservableCollection(Of T).
    ''' </summary>
    Public Sub AddRange(ByVal collection As IEnumerable(Of T))
        Dim old = Items.ToList
        For Each i In collection
            Items.Add(i)
        Next
        OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, collection, old))
    End Sub
    ''' <summary>
    ''' Removes the first occurence of each item in the specified collection from ObservableCollection(Of T).
    ''' </summary>
    Public Sub RemoveRange(ByVal collection As IEnumerable(Of T))
        Dim old = Items.ToList
        For Each i In collection
            Items.Remove(i)
        Next
        OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, Items, old))
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
        Dim old = Items.ToList
        Items.Clear()
        For Each i In collection
            Items.Add(i)
        Next
        OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, Items, old))
    End Sub
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
