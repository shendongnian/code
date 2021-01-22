    [AcceptVerbs(HttpVerbs.Post)]
    public JsonResult DeleteMusicStyleByMember(int id)
    {
        if (!(Session["MemberLoggedIn"] is Member)) return Json(string.Empty);
        Member member = (Member)Session["MemberLoggedIn"];
        _memberService.DeleteMusicStyle(member, id);
        return SelectedMusicStyles();
    }
    [AcceptVerbs(HttpVerbs.Post)]
    public JsonResult DeleteMusicStyleByBand(int id, int typeid)
    {        
        Band band = _bandService.GetBand(typeid);
        _bandService.DeleteMusicStyle(band, id);
        return SelectedMusicStyles();
    }
    [AcceptVerbs(HttpVerbs.Post)]
    public JsonResult DeleteMusicStyleByEvent
        (int id, int typeid)
    {
        Event event = _eventService.GetEvent(typeid);
        _bandService.DeleteMusicStyle(event, id);
        return SelectedMusicStyles();
    }
