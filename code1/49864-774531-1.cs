    <%= Html.TextBox( "Name", Model.Name, new { @class = "required" } ) %>
    public ActionResult SearchModels( var q, int limit )
    {
         var query = db.Models.Where( m => m.Name.StartsWith( q ) )
                              .Take( limit )
                              .Select( m => new { m.DisplayName, m.Name, m.ID } );
         return Json( query.ToList() );
    }
