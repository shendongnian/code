    public async void MyUnitTest()
    {
        // helper method to create instance of the Controller
        var controller = this.CreateController();
        var model = new MyViewModel
        {
            Name = null
        };
        // here we call the extension method to validate the model
        // and set the errors to the Controller's ModelState
        controller.BindViewModel(model);
        var result = await controller.ActionName(model);
        Assert.NotNull(result);
        var viewResult = Assert.IsType<BadRequestObjectResult>(result);
    }
