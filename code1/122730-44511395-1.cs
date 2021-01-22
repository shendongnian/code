    @if (!string.IsNullOrEmpty(ViewBag.ErrorMsg))
    {
        <div>ViewBag.ErrorMsg</div>
    }
     
    @using (Html.BeginForm(...)){
        @Html.HiddenFor(x=>x.PreventResubmit)
        // Others codes of the form
    }
