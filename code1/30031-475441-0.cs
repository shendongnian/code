    public ActionResult Test() {
    	return View<Views.Module1.Test, string>("Hello All");
    }
    
    
    protected ActionResult View<TView, TModel>(TModel model)
    	where TView : ViewPage<TModel>
    	where TModel : class {
    		return View(typeof(TView).Name, model);
    }
