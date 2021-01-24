    if (copiedValue.IsGenericTypeOf(typeof(ObservableCollection<>)))
    {
         // as the element type can be anything you cannot treat copiedValue as ObservableCollection here
         // But considering it implements nongeneric interfaces you can cast it to IList:
         IList sourceCollection = (IList)copiedValue;
         IList destinationCollection = GetDestination(copiedValue);
         destinationCollection.Clear();
         foreach (var item in sourceCollection)
             destinationCollection.Add(item);        
    }
