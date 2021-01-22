    @if (!string.IsNullOrEmpty(ViewBag.ErrorMsg))
    {
        <div>ViewBag.ErrorMsg</div>
    }
     
    @using (Html.BeginForm(...)){
        @Html.HiddenFor(x=>x.PreventResubmit) // << Put this Hidden Field in the form
        // Others codes of the form without any changes
    }
