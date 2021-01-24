    You can set the model type in view to         
    @model IEnumerable<WebApplication2.Models.Strategy>
    and on the view 
    if(Model != null)
    {
     foreach(var strategy in Model)
     {
      //strategy should give you all the details you need
     }
    }
