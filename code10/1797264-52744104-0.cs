    public IActionResult ParentAction()
    {
        var childController = new ChildApp.Controllers.ChildController(); // You may need to pass in any dependencies yourself
    
        return childController.ChildAction();
    }
