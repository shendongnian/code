    public ActionResult Create(int id)
    {
        CommentaarCreate_VM vm = new CommentaarCreate_VM()
        {
            Stad = _dataGentService.GetStadFromId(id),
            Commentaar = new Commentaar()
        };
        return View(vm);
    }
