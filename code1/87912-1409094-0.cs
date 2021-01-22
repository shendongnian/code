    protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
    {
        if (HttpContext.Current != null)
        {
            string baseAddress = string.Format("http://{0}{1}{2}", HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port, HttpContext.Current.Request.CurrentExecutionFilePath);
            Uri baseURI = new Uri(baseAddress);
            return base.CreateServiceHost(serviceType, new Uri[] { baseURI });
        }
    
        //We did the best we could, but there is no current HTTP request.
        //Just fall back to the base service host factory
        return base.CreateServiceHost(serviceType, baseAddresses);
    }
