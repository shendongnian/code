    public class TaskEditViewModel
    {
        // …
        public string ProjectId { get; set; }
        public IEnumerable<SelectListItem> AvailableProjects { get; set; }
    }
    // in the controller
    return View(new TaskEditViewModel
    {
        ProjectId = "value-3",
        AvailableProjects = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Item 1", Value = "value-1" },
            new SelectListItem { Text = "Item 2", Value = "value-2" },
            new SelectListItem { Text = "Item 3", Value = "value-3" },
            new SelectListItem { Text = "Item 4", Value = "value-4" },
        },
    });
    // in the view
    <select asp-for="ProjectId" class="form-control" asp-items="Model.AvailableProjects"></select>
