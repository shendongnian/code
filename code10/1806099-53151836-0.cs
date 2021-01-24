        public async Task<ActionResult> Create(Inbox model, IEnumerable<HttpPostedFileBase> files)
            {
    List<Inbox>lst=new List<Inbox>();
                var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
                if (ModelState.IsValid)
                {
                    model.User = currentUser;
                    foreach (var file in files)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/FilesAPP"), fileName);
                            file.SaveAs(path);
                            path = Url.Content(Path.Combine("~/FilesAPP", fileName));
    lst.add(new Inbox{Files=path});
    //you files added here
                        }
                    }
                    db.Inboxs.Add(model);
                    db.SaveChanges();
                    string url = Url.Action("List");
                    return Json(new { success = true, url = url });
                }
                return View(model);
            }
