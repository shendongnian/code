    [HttpGet] 
    public ActionResult EditMember(int id)
    {
    	var member = db.member..SingleOrDefault(x => x.Id == id);
    
    	if (member != null)
    	{
    		var memberViewModel = new MemberViewModel();
    		memberViewModel.MemberID = member.Id;
    		memberViewModel.FirstName = member.FirstName;
    		memberViewModel.LastName = member.LastName;
    		return View(memberViewModel);
    	}
    
    	return View();
    }
    	
    
    [HttpPost]
    [ValidateAntiForgeryToken] 
    public ActionResult EditMember(Member model)
    {
    	Member members = new Member();
    	var member = DBContext.Members.Find(model.MemberID);
    
    	if (member == null)
    	{
    		return HttpNotFound();
    	}
    
    	if(ModelState.IsValid)
    	{                                
    		DBContext.SaveChanges();
    	}
    
    	return View(member);
    }
