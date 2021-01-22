    dim myAItem AS A = (from x in db.As WHERE x.CardID == MyGUIDValue).SelectSingleOrDefault
    
    ' Assign Variables Here
    Me.AValue1 = myAItem.FromDbValue1
    
    dim itemColl = (from b in db.Bs on b == MyGUIDValue).ToList 
    
    me.ItemList = New List(of MySubClass)
    For each bItem as B in itemColl
       dim item as New MySubClass
       'Assign Variables Here, ex: item.Value1 = bItem.MyDbValue1
       me.ItemList.Add(item)
    Next
