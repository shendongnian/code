       var list = db.Table
                    .Select( t => new SelectListItem
                                  { 
                                      Key = t.ID.ToString(),
                                      Value = t.Name
                                  } );
       list.Insert( 0, new SelectListItem { Key = "-1", Value = "All" } );
       ViewData["TableSelect"] = list;
