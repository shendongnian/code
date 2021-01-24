            public ActionResult Index()
        {
            var branches = db.Branches;
            var query = from child in branches
                join parent in branches on child.ParentId equals parent.Id into parentJoin
                select new 
                {
                    Id = child.Id,
                    ParentId = child.ParentId,
                    Name = child.Name,
                    ParentName = parentJoin.FirstOrDefault().Name
                };
            var result = query.ToList().Select(e => new Branch
            {
                Id = e.Id,
                ParentId = e.ParentId,
                Name = e.Name,
                ParentName = e.ParentName
            }).ToList();
            return View(result);
        }
