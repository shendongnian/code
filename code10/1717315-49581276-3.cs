    [HttpPost]
            public ActionResult ProcessForm(Notice notice, HttpPostedFileBase file)
            {
                if (file != null)
                {
                    var fileName = Guid.NewGuid() + "-" + file.FileName;
                    notice.ImagePath = Server.MapPath(Path.Combine("~/uploads/notice/" + fileName));
    
                    file.SaveAs(notice.ImagePath);
                }
    
                if (notice.Id == 0)
                {
                    //notice.DatePosted = DateTime.Now;
                    _context.Notice.Add(notice);
                }
                else
                {
    
                    _context.Entry(notice).State = EntityState.Modified;
    
                    //var noticeInDb = _context.Notice.Single(n => n.Id == notice.Id);
    
                    //notice.Title = noticeInDb.Title;
                    //notice.Description = noticeInDb.Description;
                    //notice.ImagePath = noticeInDb.ImagePath;
                    //notice.IsPublic = noticeInDb.IsPublic;
                }
                //_context.Notice.Add(notice);
    
                _context.SaveChanges();
    
                return View("Index", _context.Notice);
            }
