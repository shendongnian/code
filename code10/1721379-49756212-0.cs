    private void IterateTree(ItemCollection items)
    {     
        //Iterate each item
        foreach (var item in items)
        {
            //Your IF logic here
            //Iterate again if item contains sub items.
            if (item is ItemsControl)
            {
                ItemsControl ic = (ItemsControl)item;
                IterateTree(ic.Items); //Recursive call
            }
        }      
     }
