    [HttpGet]
    public async Task<ActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        SparesSection sparesSection = await _bs.SparesSection_GetAsync(id.Value);
        if (sparesSection == null)
        {
            return HttpNotFound();
        }
        return View(sparesSection);
    }
