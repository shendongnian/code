     public PartialViewResult Test1(MainModel model)
                {
                 if(string.IsNullOrWhiteSpace(Model.ModelB.Test1)
                   {
                    ModelState.Remove("Model.ModelB.Test2");
                    if (TryValidateModel(model.ModelA)) 
                     {
                        return PartialView("Index", model);
                     }
                    return PartialView("Index");
                   }
                   
                }
