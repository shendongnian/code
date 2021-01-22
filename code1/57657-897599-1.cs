    Public Sub UpdateWithList(MyList as AList, View as AView)
      Me.SetListTitle MyList.Name
      For I = View.MyListStart to View.MyListEnd
         Me.AddListItem MyList(I)
      Next I
      Me.ShowListAddBUtton
      Me.ShowListDelButton
    End Sub
