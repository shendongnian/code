    @model YourNamespaceGoesHere.EditUserVm
    @using (Html.BeginForm())
    {
      @Html.HiddenFor(a=>a.Id)
      <label>@Model.UserName</label>
    
      @Html.LabelFor(a=>a.Admin)
      @Html.CheckBoxFor(a=>a.Admin)
      @Html.LabelFor(a=>a.Gost)
      @Html.CheckBoxFor(a=>a.Gost)
      @Html.LabelFor(a=>a.PravoUnosa)
      @Html.CheckBoxFor(a=>a.PravoUnosa)
      <button type="submit" >Save</button>
    }
