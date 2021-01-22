    //CompressFilter class
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      bool inLiveMode = bool.Parse(ConfigurationManager.AppSettings["InLiveMode"]);
      if(inLiveMode)
      {
        //Do the compression shiznit
      }
    }
