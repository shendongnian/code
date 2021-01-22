    Protected Overrides Sub OnCollectionChanged(e As NotifyCollectionChangedEventArgs)
        If e.Action = NotifyCollectionChangedAction.Add AndAlso e.NewItems.Count > 1 Then
            Dim handler As NotifyCollectionChangedEventHandler = GetType(ObservableCollection(Of T)).GetField("CollectionChanged", BindingFlags.Instance Or BindingFlags.NonPublic).GetValue(Me)
            For Each invocation In handler.GetInvocationList
                If TypeOf invocation.Target Is ICollectionView Then
                    DirectCast(invocation.Target, ICollectionView).Refresh()
                Else
                    MyBase.OnCollectionChanged(e)
                End If
            Next
        Else
            MyBase.OnCollectionChanged(e)
        End If
    End Sub
