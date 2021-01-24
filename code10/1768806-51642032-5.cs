    public class DetailsViewModel
    {
        public int Id {get;set;}
        public IList<Example.Areas.ExamplePage.Models.Example> Examples {get;set;}
    }
    public IActionResult Details(int id)
    {
        var example = from a in db.Example
              where a.ExamplePresent
              orderby a.ExampleName
              select a;
        return View(new DetailsViewModel{ Id = id, Examples = example.ToList() });
    }
    @model DetailsViewModel
    @{
        ViewData["Title"] = "Details";
    }
    <h2>id: @Model.Id</h2> // your list is @Model.Examples
