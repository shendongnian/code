    var groupedCycles = cycles.GroupBy(x => new 
    { 
      Prop1 = x.Column1, 
      Prop2= x.Column2 
    })
	
	foreach (var groupedCycle in groupedCycles)
    {
        var key = new Key();
        key.Prop1 = groupedCycle.Key.Prop1;
        key.Prop2 = groupedCycle.Key.Prop2;
    }
