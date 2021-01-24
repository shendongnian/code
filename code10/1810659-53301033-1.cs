    public ActionResult Request(Events e)
        {
            //Check whether "e" is null or not
            if (e != null)
            {
                //Check whether "file1" is null or not
                if (e.file1 != null && e.file1.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(e.file1.FileName);
                    string extension = Path.GetExtension(e.file1.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    e.file_one = "PM_Files/" + filename;
                    filename = Path.Combine(Server.MapPath("~/PM_Files/"), filename);
                    e.file1.SaveAs(filename);
                }
                //Check whether "file2" is null or not
                if (e.file2 != null && e.file2.ContentLength > 0)
                {
                    string Second_filename = Path.GetFileNameWithoutExtension(e.file2.FileName);
                    string Second_extension = Path.GetExtension(e.file2.FileName);
                    Second_filename = Second_filename + DateTime.Now.ToString("yymmssfff") + Second_extension;
                    e.file_two = "PM_Files/" + Second_filename;
                    Second_filename = Path.Combine(Server.MapPath("~/PM_Files/"), Second_filename);
                    e.file2.SaveAs(Second_filename);
                }
                _context.evt.Add(e);
                _context.SaveChanges();
                return Content("Added");
            }
            else
            {
                return Content("Event is empty");
            }
        }
