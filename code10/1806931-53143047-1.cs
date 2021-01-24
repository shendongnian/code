        [HttpPost] 
        public ActionResult Create (CallViewModel callViewModel) {
            var model = new ModelClass;
            
            model.Id = callViewModel.Id;
            model.ChildModel = callViewModel.ChildModel;
    
            _context.Add(model);
            _context.SaveChanges();
    
            return RedirectToAction("Index");
        }
