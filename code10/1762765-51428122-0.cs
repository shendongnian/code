        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Updateto(GitJSON gitjson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //here is sample code to map changes to entities
                    var gitdIds = gitjson.gitdList.Select(x => x.Id).ToList;
                    _context.gitds
                        .Where(x => gitdIds.Contains(x.Id))
                        .ToList()
                        .ForEach(x =>
                        {
                            //find match data
                            var change= data.gitdList.FirstOrDefault(d => d.Id == x.Id);
                            //update your fields here
                            x.Name = change.Name;
                                    ...
                        });
                     //save changes after updated entities
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message// or ex.ToString()
                });
                // or return RedirectToPage("Error", ex);
            }
        }
