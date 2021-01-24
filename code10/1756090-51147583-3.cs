    @using System.Web.Helpers
    @model Chart
    
    @{
        ViewBag.Title = "Mega Chart";
        Layout = "~/Views/Shared/_Layout2.cshtml";
    }
     
    @{
        Model.Write(format: "png");
    }
