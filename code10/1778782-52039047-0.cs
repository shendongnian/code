    var myDictionary = new Dictionary<string, string>()
		{
			{"x" ,"y" }
		}; 
	var listIWantToRetriveWithDictKeys = MyDbContext.Documents.ToList().Where(c => c.SomethingLikeX != null && myDictionary.Keys.Contains(c.SomethingLikeX)).Select(id => id.documentID).ToList();
	var listaIWantToRetriveWithDictValues = Documents.Where(o => c.somethingLikeY != null && myDictionary.Values.Contains(o.somethingLikeY.ToString())).Select(i => i.documentID).ToList();
	
