    public async Task<IActionResult> Index () {
        var prerenderResult = await this.Request.BuildPrerender ();
        this.ViewData["SpaHtml"] = prerenderResult.Html; // our <app-root /> from Angular
        ....
 
        return View();
    }
    
