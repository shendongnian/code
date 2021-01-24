    [HttpGet]
        public ActionResult Settings(Int64? id, string returnUrl)
        {
            List<Keyword> objKeywordList = new List<Keyword>();
            List<SelectListItem> ProfileVisibility = new List<SelectListItem>();
            NurseProfileVisibility objNurseProfileVisibility = new NurseProfileVisibility();
            Int64 NurseId = ApplicationSession.CurrentUser.NurseId;
            objNurseProfileVisibility.NurseId = NurseId;
            SelectListItem objSelect = new SelectListItem { Text = "Profile Visibility", Value = "", Selected = true };
            objKeywordList = objKeywordDAL.GetKeywordsByType("ProfileVisibility").Results;
            var visibilityOption = (from kl in objKeywordList
                                    select new SelectListItem
                                    {
                                        Text = kl.KeywordText,
                                        Value = kl.KeywordValue.ToString(),
                                        Selected = false
                                    }).ToList();
            if (id != 0)
            {
                Result res = objNurseDAL.GetProfileVisibilityById(NurseId);
                if (res.Status)
                {
                    if(res.Results != null) {
                        objNurseProfileVisibility = res.Results;
                        if (objNurseProfileVisibility.NurseId != NurseId)
                        {
                            visibilityOption.FirstOrDefault(x => x.Value == objNurseProfileVisibility.ProfileVisibilityId.ToString()).Selected = true;
                        }
                    }
                }
            }
            ViewBag.VisibilityOptions = visibilityOption;
            ViewBag.returnUrl = returnUrl;
            return View(objNurseProfileVisibility);
        }
