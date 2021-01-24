    [HttpGet]
    [Route("data/links/edit/{id}")] // GET data/links/edit/2
    public async Task<ActionResult> Edit(int? id) {
        // ....
        return View(link);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("data/links/edit/{id}")] // POST data/links/edit/2
    public async Task<ActionResult> Edit(int id, [Bind(Include = "Id,LinkText,Url,Image,Description")] Link link) {
        // ....
        return this.RedirectToAction("Index");
    }
