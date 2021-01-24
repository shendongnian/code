    var list = new List<CustomObject>
    {
    	new CustomObject{ID=1, Name="Abc",Type="Type1"},
    	new CustomObject{ID=2, Name="Def",Type="Type2"},
    	new CustomObject{ID=3, Name="Abc",Type="Type1"},
    	new CustomObject{ID=4, Name="Abc",Type="Type2"},
    	new CustomObject{ID=5, Name="Def",Type="Type2"},
    	new CustomObject{ID=6, Name="Def",Type="Type1"},
    };
    
	var result = list.GroupBy(x=>new{x.Name,x.Type})
					 .Where(x=>x.Count()>1)
					 .SelectMany(x=>x.ToList()).Select(x=>x.ID);
