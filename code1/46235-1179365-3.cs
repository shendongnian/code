        public ActionResult Edit(Team editedTeamData)
        {
            if (!ModelState.IsValid)
                return View();
            Team origTeam = (from t in _db.Teams
                             where t.TeamID == editedTeamData.TeamID
                             select t).FirstOrDefault();
            origTeam.ApplyPropertyChanges(editedTeamData);
            _db.SubmitChanges();
            return RedirectToAction("Index");
                
        }
