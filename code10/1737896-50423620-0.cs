     var blogging02Context = _context.Tag;
    
                if (!string.IsNullOrEmpty(Urlid.ToString()))
                {
                    blogging02Context = blogging02Context.Where(t => t.Urlid == Urlid);
                }
    
                blogging02Context = blogging02Context.Include(t => t.Blog);
    
                ViewBag.Urlid = Urlid;
