    @{
        if (ViewData["class"] != null) { ViewData["class"] += " datepicker"; }
        else { ViewData["class"] = " datepicker"; }
        string format = "MM/dd/yyyy";
        if (ViewData["format"] != null)
        {
            format = ViewData["format"].ToString();
            ViewData.Remove("format");
        }
    }
    
    @Html.TextBox("", (Model.HasValue ? Model.Value.ToString(format) : string.Empty), ViewData)
