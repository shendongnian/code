    public async Task GetinfoAsync()
    {
    	var vm = new MyViewModel();
    	
    	vm.Name = "Jeremy";
    
    	this.BindingContext = vm;
    
    }
