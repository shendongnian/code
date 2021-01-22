     var model = new ViewModel();
     model.ActiveList = new List<SelectListItem>
                        {
                            new SelectListItem { Text = "Yes", Value = "true" },
                            new SelectListITem { Text = "No", Value = "false" }
                        };
     model.Active = false; // this will be the default
     return View( model );
