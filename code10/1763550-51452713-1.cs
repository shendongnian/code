    public ActionResult Details (int id) {
            Project project = _context.Projects.Include(i => i.Images)
                .Where (i => i.Id == id)
                .SingleOrDefault ();
            if (project == null)
                return HttpNotFound ();
            return View (project);
        }
