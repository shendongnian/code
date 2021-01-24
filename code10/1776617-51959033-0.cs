                var data = from o in _mainDbContext.Blogs
                        join u in _userManager.Users.ToList() on o.EditorID equals u.Id
                        select new BlogViewModel
                        {
                            Id = o.Id,
                            Title = o.Title,
                            Editor = u.UserName
                        };
            var result = data2.ToList();
