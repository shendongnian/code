    public class CommentViewModel
    {
        public virtual Comment Comment { get; set; }
        public virtual UserProfile User { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
    var comments = (
      from c in _context.Comments
      join u in _context.UserProfiles on c.UserId equals u.Id
      select new CommentViewModel
      {
        Comment = c,
        User = u,
        Roles = (
          from ur in _context.UserRoles
          join r in _context.Roles on ur.RoleId equals r.Id
          where ur.UserId == u.Id
          select r)
      });
