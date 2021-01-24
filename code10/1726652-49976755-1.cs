        public virtual ActionResult Edit(long id, EditModel model)
        {
            try
            {
                if (setForeignKeyActionList == null)
                    setForeignKeyActionList = SetForeignKeyProperties();
                setForeignKeyActionList.ForEach(action => action(Repository, model.SourceModel));
                Repository.SaveItem<ViewModel, EditModel>(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex);
                return View(Repository.GetEditableItem<ViewModel, EditModel>(id));
            }
        }
