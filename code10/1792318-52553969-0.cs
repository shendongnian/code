     public ActionResult EditPost(int? id, string[] selectedGroups)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // var courseToUpdate = db.Pracownicy.Find(id);
      var userToUpdate = db.sprawy
                .Include(i => i.Usergroups)
                 .Where(i => i.UserName  == 'user')
                 .Single();
            if (TryUpdateModel(userToUpdate, "",
              new string[] { "UserName","Email" }))
            {
                try
                {
                    AddorUpdate(userToUpdate, selectedGroups);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(userToUpdate);
        }
 
 
    private void AddorUpdate(User spr, string[] selected)
        {
            spr.Usergroups = new List<Usergroup>();
            if (selected == null)
            {
                spr.Usergroups = new List<Usergroup>();
                return;
            }
            var selectedGroupHS = new HashSet<string>(selected);
            var Usergroup = new HashSet<int>(spr.Usergroups.Select(c => c.Group_Id));
            foreach (var ug in db.Usergroup)
            {
                if (selectedGroupHS.Contains(ug.Group_Id.ToString()))
                {
                    if (!Usergroup.Contains(ug.Group_Id))
                    {
                        spr.Usergroups.Add(ug);
                    }
                }
                else
                {
                    if (Usergroup.Contains(ug.Group_Id))
                    {
                        spr.Usergroups.Remove(ug);
                    }
                }
            }
        }
		  modelBuilder.Entity<User>()
           .HasMany(c => c.Usergroups).
		    WithMany(i => i.Users)
           .Map(t => t.MapLeftKey("User_ID")
               .MapRightKey("Usergroups_Id")
               .ToTable("UsergroupOverview"));
