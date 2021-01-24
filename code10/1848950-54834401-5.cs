    [HttpPost]
    public IActionResult Edit(TaskEditViewModel model)
    {
        var selectedProject = model.ProjectId; // "value-3"
        // …
    }
