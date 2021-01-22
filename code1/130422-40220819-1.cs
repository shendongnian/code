    `....
      lstInCallList.ItemsSource = ContactCallList
      AddHandler ContactCallList.CollectionChanged, AddressOf collectionInCall_change
    .....
    Public Sub collectionInCall_change(sender As Object, e As NotifyCollectionChangedEventArgs)
        'Whenever collection change we must test if there is no selection and autoselect first.   
        If e.Action = NotifyCollectionChangedAction.Add Then
            'The solution is this, but this shouldn't be necessary
            'Dim seleccionado As RadioButton = getCheckedRB(lstInCallList)
            'If seleccionado IsNot Nothing Then
            '    seleccionado.IsChecked = False
            'End If
            DirectCast(e.NewItems(0), PhoneCall).Selected = True
    .....
    End sub
`
