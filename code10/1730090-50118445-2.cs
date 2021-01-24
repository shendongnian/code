    @model AspNetMvc.Models.IncidentListmodel
    
    @using (Html.BeginForm("Updateinc", "Home"))
    {
        @Html.HiddenFor(m => m.Id)
        @Html.HiddenFor(m => m.Name)
    
        @Html.DisplayFor(m => m.Name)
        @Html.DisplayFor(m => m.Title)
    
        @Html.TextAreaFor(m => m.Note, 2, 20, new { maxlength = 50 })
    
        <button type="submit">Update</button>
    }
