        /// <summary>
        /// Return summary details about the groups a user belongs to
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<Group> GroupsForUser(int userId)
        {
            DataAccess.KINv2DataContext db = new DataAccess.KINv2DataContext();
            List<Group> groups = new List<Group>();
            groups = (from g in db.Groups
                      join gu in db.GroupUsers on g.GroupId equals gu.GroupId
                      where g.Active == true && gu.UserId == userId
                      select new Group
                      {
                          GroupId = g.GroupId,
                          Name = g.Name,
                          CreatedOn = g.CreatedOn,
                          ContactCount = (from c in db.Contacts where c.OwnerGroupId == g.GroupId select c).Count(),
                          MemberCount = (from guu in db.GroupUsers where guu.GroupId == g.GroupId 
                                         join u in db.Users on guu.UserId equals u.UserId
                                         where u.Active == true 
                                         select gu ).Count()
                      }).ToList<Group>();
            return groups;
        }
