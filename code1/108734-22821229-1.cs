    @helper RunnerLink(PersonSearch model, int page)
    {
        var routeParms =new RouteValueDictionary(model.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(model, null)));
        routeParms.Add("page", page.ToString());
        routeParms.Add("Controller", "Property");
        @Html.ActionLink("Search", "Index", routeParms)
    }
