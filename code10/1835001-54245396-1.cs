public class PortfolioDetailsVM
{
    //...
    public Portfolio Portfolio { get; set; }
    public PortfolioProject PortfolioProject { get; set; }
    public IEnumerable<Project> Projects { get; set; }
}
This should make your binding code work.
Better binding models
---------------------
Second, you are using Model Binding in a slightly incorrect way. Try not to bind directly to your data models (e.g. the type of PortfolioProject). The model you're binding to shouldn't contain any reference to data model types.
Instead, I usually only declare what I really need in the model I'm binding to, so that I won't ever have to use that ol' `Bind` attribute in the first place. A simple example for your case:
public class DetailsAddProjectVM
{
    public string SelectedProjectId { get; set; }
}
With a corresponding form:
@model PortfolioDetailsVM
<select asp-for="SelectedProjectId" class="custom-select form-control">
   ...
</select>
which posts to 
public async Task<IActionResult> AddProject(DetailsAddProjectVM bindingModel)
{
   //look ma, no [Bind]!
   var projectid = bindingModel.SelectedProjectId;
}
Of course, for the corresponding form to render, you'd also have to declare a `SelectedProjectId` property in your original `PortfolioDetailsVM`.
As you can see, you don't **have** to bind to your original View Model at all.
