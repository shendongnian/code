    public IActionResult Create([FromRoute] int id) //id = InquiryID
    {
        CommentVM model = new CommentVM
        {
            InquiryID = id
        }
        return View(model);
    }
