    public ActionResult Post([FromBody] UserViewModel viewModel) {
        if(ModelState.IsValid) {
            //create new model
            var model = new UserModel {
                Username = viewModel.Username,
                Email = viewModel.Email,
                Password = viewModel.Password
            };
            
            //or model retrieved from data storage
            
            //...some other code...
            
            model.IsValid = true; //only the server can modify this value
            
            //...
        }
        
        //...
    }
    
