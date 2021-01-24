    public virtual ActionResult Method()
        {
            MyViewModel vm = new MyViewModel();
            vm.Name = "MyName";
            return View(MVC.Controller.Views.MyView, vm); //also works with partial views
        }
