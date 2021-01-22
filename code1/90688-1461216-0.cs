    public void TransactionalMethod()
    {
        var items = GetListOfItems();
    
        try {
            foreach (var item in items)
            {           
                MethodThatMayThrowException(item);
    
                item.Processed = true;
            }
        }
        catch(Exception ex) {
            foreach (var item in items)
            {
                if (item.Processed) {
                    UndoProcessingForThisItem(item);
                }
            }
        }
    }
