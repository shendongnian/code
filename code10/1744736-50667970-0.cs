    public async Task<ActionResult> Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Project project = await db.Projects.FindAsync(id);
        if (project == null)
        {
            return HttpNotFound();
        }
        // returning a single item, not a collection
        return View(project);
    }
