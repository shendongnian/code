            public IActionResult About()
        {
            IList<Blog> blogs = new List<Blog>();
            var user = (WindowsIdentity)User.Identity;
            WindowsIdentity.RunImpersonated(user.AccessToken, () =>
            {
                var impersonatedUser = WindowsIdentity.GetCurrent();
                blogs = _context.Blogs.ToList();
            });
            return Ok(blogs);
        }
