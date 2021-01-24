    @inherits UmbracoTemplatePage
    @{
        var child = Model.Content.Children.FirstOrDefault();
        var properties = new List<string>();
        foreach (var item in child.Properties)
        {
            properties.Add(item.PropertyTypeAlias);
        }
    }
    @foreach (var item in properties)
    {
        <h1>@item</h1>
    }
