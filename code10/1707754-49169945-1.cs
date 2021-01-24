    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Question question, string[] techIds)
    {
       UpdatePostCategories(question, techIds);
       ....
       _context.Questions.Add(question);
       _context.SaveChanges();
    }
