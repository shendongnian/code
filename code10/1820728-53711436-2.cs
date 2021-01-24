    public class MyViewModel
    {
      public string Title { get; set;}
      public IEnumerable<Person> People { get; set;}
    }
    
    return View(myViewModel);
    @model MyViewModel
