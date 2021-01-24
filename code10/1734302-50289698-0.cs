    foreach (TransactionTP b in matrix)
    {
        int itemCount = 0;
        //remember to null check to be defensive
        if (b.itemsUtilities != null)
        {
            foreach(ItemUtility c in b.itemsUtilities)
            {
                itemCount += c.item;
            }
        }
        //presuming this is an console app?
        Console.Write(itemCount);
    }
