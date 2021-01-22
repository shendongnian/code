    public void BuyMoreStuff(Item[] cart, ref Decimal totalCost, Item i)
    {       
        CodeContract.Requires(totalCost >=0);
        CodeContract.Requires(cart != null);
        CodeContract.Requires(CodeContract.ForAll(cart, s => s != i));
    
        CodeContract.Ensures(CodeContract.Exists(cart, s => s == i);
        CodeContract.Ensures(totalCost >= CodeContract.OldValue(totalCost));
        CodeContract.EnsuresOnThrow<IOException>(totalCost == CodeContract.OldValue(totalCost));
    
        // Do some stuff
        …
    }
