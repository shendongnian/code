    public ActionResult InsertDetail(MemberViewModel model)
            {
                if (ModelState.IsValid)
                {
                    // Get context (this should be done through a repository but let's focus)
                    using (var ctx = new ApplicationDbContext())
                    {
                        var member = new Member();
    
                        if (model.Id == null)
                        {
                            // Insert Member
                            member.Name = model.Name;
                            member.Email = model.Email;
                            ctx.Members.Add(member);
                        }
                        else
                        {
                            // Check if Id already exists
                            member = ctx.Members.FirstOrDefault(x => x.Id == model.Id);
                            if (member != null) // this member already exists
                            {
                                // You can decide to throw an error or update the entity. Let's throw error
                                ModelState.AddModelError("", "Member Already Exists");
                                return View(model);
                            }
                        }
                    }
                }
                // If you get here then there is a validation error
                return View(model);
            }
