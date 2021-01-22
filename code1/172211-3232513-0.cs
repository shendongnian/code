    List<Slice> slicesToEat=new List<Slice>();
    foreach(var Slice in Pizza)
    {
        if(Slice.Flavor == "Sausage")
        {
            slicesToEat.Add(Slice); 
        }
    }
    foreach(var slice in slicesToEat)
    {
        Me.Eat(slice);
    }
