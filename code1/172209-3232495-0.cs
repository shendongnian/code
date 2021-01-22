    for(int i = 0; i < in Pizza.Count(), ++i)
    {
    
        var Slice = Pizza[i];
        if(Slice.Flavor == "Sausage")
        {
            Me.Eat(Slice); //This removes an item from the list: "Pizza"
        }
    }
