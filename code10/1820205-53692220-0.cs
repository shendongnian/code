    public async Task<ActionResult> NewAction(int id) {
        var project = await _repository.GetProjectFromIdAsync(id);
        if (project == null) return HttpNotFound();
        return RedirectToAction("ExistingAction", new { id = project.Id });
    }
