    [HttpPost]
    public ActionResult EditTask(UpdateTaskViewModel model)
    {
        Alert alert;
        if (ModelState.IsValid)
        {
            try
            {
                DatabaseOperations.UpdateTask(
                    model.TaskId,
                    model.Title,
                    model.Description,
                    EacId,
                    model.Comment);
                alert = new Alert("Success!", "Updated task.", "alert-success");
            }
            catch (Exception e)
            {
                alert = new Alert("Error!", "Failed to update task.", "alert-danger", e);
            }
        }
        else
        {
            return PartialView("_UpdateTask")
        }
        TempData["Alert"] = alert;
        return RedirectToAction("Index");
    }
