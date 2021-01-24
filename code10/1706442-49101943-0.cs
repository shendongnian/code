	public async Task MyTestMethod() {
		//...
		//Act
        var viewResult = await controller.ManageBills(2); 
		 
		ManageBillsViewModel result = viewResult.ViewData.Model as ManageBillsViewModel;
		
		//Assert
		
		//...
	}
	
