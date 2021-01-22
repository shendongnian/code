    [Fact]
    public void List_Action_Provides_ProjectCollection()
    {
    	//act
    	var result = controller.List();
    
    	//assert
    	var viewresult = Assert.IsType<ViewResult>(result);
    	Assert.NotNull(result.Model);
    	Assert.IsType<List<string>>(result.Model);
    }
