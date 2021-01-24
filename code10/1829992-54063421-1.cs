    // Menu Controller
    public class NavController : Controller
    {
        public PartialViewResult Menu(string searchText = null)
        {
            return PartialView("MenuPartial", searchText);
        }
    }
Update your Menu PartialView to use a string model and set the value of the search box:
    <!-- Menu PartialView -->
    @model string
    @using (Html.BeginForm("All", "List"))
    {
        @Html.TextBox("SearchText", Model) // searchText should be here
        <button type="submit"></button>
    }
I suggest once you get this working that you go back and give the Menu PartialView its own view model that contains a SearchText property.
