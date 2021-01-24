    public async Task<IActionResult> Create([FromForm]CommentVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        Comment comment = new Comment
        {
            InquiryID = model.InquiryID,
            Text = model.Text,
            TimePosted = DateTime.Now,
            .... // set other properties (User etc) as required
        };
        // save and redirect
        ....
    }
    
