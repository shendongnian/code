    public void CreateUniqueBuyList(List<EveObjModel> buyList)
    {
    	//sort by ascending type_id and then by ascending price and reverse it. so that,
    	// object with higher price come first
    	List<EveObjModel>tempList = buyList.OrderBy(x => x.type_id).ThenBy(x => x.price).Reverse().ToList();
    	List<EveObjModel> uniqueBuyList = new List<EveObjModel>();
    	for (int i = 0; i < tempList.Count; ++i) {
    		if ((i > 1) && tempList[i - 1].type_id == tempList[i].type_id) continue; // if duplicate type_id then don't take it again
    		uniqueBuyList.Add(tempList[i]);
    	}
    	foreach (EveObjModel item in uniqueBuyList.OrderBy(item => item.type_id))
        {
            buyListtextField.Text += $"Eve Online Item! Type-ID is: {item.type_id}, Price is {item.price}\n";
        }
    }
