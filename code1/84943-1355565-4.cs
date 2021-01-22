    public class MyFormViewModel
    {
      public string myInput {get; set;}
    }
    
    public ActionResult Search()
    {
      MyFormViewModel fvm = new MyFormViewModel();
      return View(fvm);
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Search(FormCollection collection)
    {
      MyFormViewModel fvm = new MyFormViewModel();
      TryUpdateModel<MyFormViewModel>(fvm);
    
      string userInput = fvm.myInput;
    }
