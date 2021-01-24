    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "SparesSectionId,SparesSectionTitle")] SparesSection sparesSection)
    {
        if (ModelState.IsValid)
        {
            await _bs.SparesSection_UpdateAsync(sparesSection, ModelState);
    
            if (ModelState.IsValid)
            {
                ViewMessage = "Saved " + sparesSection.SparesSectionTitle;
                return RedirectToAction("Index");
            }
        }
        return View(sparesSection);
    }
