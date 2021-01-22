    public virtual string RenderToString(string viewPath, string masterPath)
    {
        ControllerContext controllerContext = this.ControllerContext;
        Stream filter = null;
        ViewPage viewPage = new ViewPage();
        
        viewPage.ViewContext = new ViewContext(this.ControllerContext, new WebFormView(viewPath, masterPath), this.ViewData, this.TempData);
    
        //get the response context, flush it and get the response filter.
        var response = viewPage.ViewContext.HttpContext.Response;
        response.Flush();
        var oldFilter = response.Filter;
    
        try
        {
            //put a new filter into the response
            filter = new MemoryStream();
            response.Filter = filter;
    
            //render the view into the memorystream and flush the response
            viewPage.ViewContext.View.Render(viewPage.ViewContext, viewPage.ViewContext.HttpContext.Response.Output);
            response.Flush();
    
            //read the rendered view
            filter.Position = 0;
            var reader = new StreamReader(filter, response.ContentEncoding);
            return reader.ReadToEnd();
        }
        finally
        {
            //Clean up.
            if (filter != null)
            {
                filter.Dispose();
            }
    
            //Now replace the response filter
            response.Filter = oldFilter;
        }
    }
