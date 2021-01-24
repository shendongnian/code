           @using (Ajax.BeginForm("AddOption", "Manage",null, new AjaxOptions { OnSuccess = "handleSavedOptionChoice(data)", HttpMethod = "Post" }))
            
            
                public ActionResult AddOptionChoice([System.Web.Http.FromBody]OptionViewModel model)
                {
                    ***content of function***
                }
