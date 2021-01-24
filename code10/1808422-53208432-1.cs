    [HttpGet]
    [Authorize]
    public async Task<ActionResult> Profile()
    {
        int agencyID = (int)User.FindFirst(ClaimTypes.NameIdentifier).Value
        int contactID = (int) User.FindFirst(ClaimTypes.Sid).Value
        
        Candidate can = await Repository.GetCandidate(agencyID, contactID, string.Empty, string.Empty, hostingEnv.WebRootPath);
        if (can.ContactID == 0)
        {
    	    int id = agencyID;
    	    return RedirectToAction("Agency", new { agencyID = id });
        }
        return View("Profile", can);
    }
