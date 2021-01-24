    @model TestApp.Models.Model
    
    @{
        ViewBag.Title = "BranchView";
    }
    
    <h2>BranchView</h2>
    
    @foreach(var item in Model.EnrollmentStudentGroups)
    {
        <p>@item.Id</p>
        <p>@item.Name</p>
        <p>@item.A_Status</p>
        <p>@item.Branchname</p>
    }
