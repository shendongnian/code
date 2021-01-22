    // View Model
    public class MyViewModel
    {
        public int CurrentPage { get; set; }
        public IList<SomeObject> Items { get; set; }
    }
    
    // Action Method
    public ActionResult List(int? page, string sort, string direction)
    {
        return View(new MyViewModel()
        {
            CurrentPage = page ?? 1,
            Items       = _myRepository.GetPagedList(page, sort, direction);
        });
    }
    
    // View
    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyProject.Controllers.MyController.MyViewModel>" %>
    ...
    
    <%= Html.ActionLink("Next", "List", new { page = Model.CurrentPage + 1, sort = "Title", direction = "ASC" }) %>
    
    <% foreach (SomeObject obj in Model.Items) { %>
        <!-- Display each item -->
    <% } %>
