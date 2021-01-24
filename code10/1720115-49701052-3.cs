    public class MyViewModel
    {
        // Replace T here with your domain model fetched from Model.GetItemList()
        public List<T> Items { get; set; }
    }
    public ActionResult Name()
    {
        // Previous action logic here...
        var myViewModel = new MyViewModel { Items = Model.GetItemList() }
        return View(myViewModel);
    }
