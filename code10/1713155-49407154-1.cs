    @inherits UmbracoViewPage<Lecoati.LeBlender.Extension.Models.LeBlenderModel>
    @foreach (var item in Model.Items)
    {       
        var listitems = item.GetValue<List<IPublishedContent>>("checkpointlist"); 
        foreach (var listitem in listitems)
        {  
            <p>@listitem.Name</p>
        }
    }
