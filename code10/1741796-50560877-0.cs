	If  SearchPanelDto.SelectedProductsList returns list of Ids then 
	
		Var searchedProductsIds = SearchPanelDto.SelectedProductsList;	
	
		var userList = listOfUsers.Where(m =>
							searchedProductsIds.Any(x=> m.IntrestetProducts.Select(t => t.ProductId).Any(z => x.Equals(z))));
							
	
	else if SearchPanelDto.SelectedProductsList return list of object which contains Id  
	
					
		//Get selected productIds from search panel
		Var searchedProductsIds = SearchPanelDto.SelectedProductsList.select(m=>m.ProductId).ToList();
		
		var userList = listOfUsers.Where(m =>
							searchedProductsIds.Any(x=> m.IntrestetProducts.Select(t => t.ProductId).Any(z => x.Equals(z))));
