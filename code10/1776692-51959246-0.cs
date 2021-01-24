    public List<Card> BestCards(List<Card> list){
		List<Card> listResult = list; 
		
		while (listResult.Count > 2)
			listResult = ReduceList(listResult);
		
		return listResult;
	}
	
	
	public List<Card> ReduceList(List<Card> list)
	{
		var listResult = new List<Card>(); 
		
		for(int i = 0; i <= list.Count - 1; i+=2)
		{
			if(list[i].value > list[i+1].value)
				listResult.Add(list[i]);
			else if (list[i].value< list[i+1].value)
				listResult.Add(list[i+1]);
			else if (list[i].value==list[i+1].value)
				listResult.Add(list[i].name.CompareTo(list[i+1].name) <= 0 ? list[i] : list[i+1]);
		}
		
		return listResult;
	}
