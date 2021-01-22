    public ActionResult Saved( int id )
    {
        var reportParams = db.Reports.SingleOrDefault( r => r.ID == id );
        if (reportParams == null)
           ...handle error...
        var routeValues = ParamsToRouteValueDictionary( reportParams );
        return RedirectToAction( reportParams.Action, reportParams.Controller, routeValues );
    }
    private RouteValueDictionary ParamsToRouteValueDictionary( object parameters )
    {
         var values = new RouteValueDictionary();
         var properties = parameters.GetType().GetProperties()
                                    .Where( p => p.Name != "Action" && p.Name != "Controller" );
         foreach (var prop in properties)
         {
             values.Add( prop.Name, prop.GetValue(parameters,null) );
         }
         return values;
    }
