    public async Task<IActionResult> Index () {
        var prerenderResult = await this.Request.BuildPrerender ();
        this.ViewData["SpaHtml"] = prerenderResult.Html; // our <app-root /> from Angular
        this.ViewData["Title"] = prerenderResult.Globals["title"]; // set our <title> from Angular
            this.ViewData["Styles"] = prerenderResult.Globals["styles"]; // put styles in the correct place
            this.ViewData["Scripts"] = prerenderResult.Globals["scripts"]; // scripts (that were in our header)
            this.ViewData["Meta"] = prerenderResult.Globals["meta"]; // set our <meta> SEO tags
            this.ViewData["Links"] = prerenderResult.Globals["links"]; // set our <link rel="canonical"> etc SEO tags
            this.ViewData["TransferData"] = prerenderResult.Globals["transferData"]; // our transfer data set to window.TRANSFER_CACHE = {}
        ...
 
        return View();
    }
    
