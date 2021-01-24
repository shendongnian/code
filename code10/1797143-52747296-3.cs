    @model PartialView.Models.Wizard
    @using PartialView.Models;
    @{
        ViewBag.Title = "Partial view calling";
    }
    
    @Html.PartialFor(m=>m.GetStepObject<WizardStep>(), "_Step")
