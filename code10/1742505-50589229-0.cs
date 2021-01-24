    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(byte JobId, JobWorker model) {
        If(ModelState.IsValid) {
            IList<Dto.Worker> newWorkers = model.Workers;
        
            // logic to update is here
        
            return RedirectToAction("Index", "Jobs");
        }
        return View(model);
    }
