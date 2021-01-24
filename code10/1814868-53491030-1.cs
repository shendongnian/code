    [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult AddComment(Survey survey)
            {
                if (survey == null)
                {
                    return BadRequest();
                }
                survey.Time = DateTime.Now;
                _context.Surveys.Add(survey);
                _context.SaveChanges();
    
                return Ok();
            }
