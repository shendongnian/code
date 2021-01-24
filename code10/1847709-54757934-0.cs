    [HttpGet]
    public IActionResult SearchUsers(string searchUser, string id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var isUserAdmin = _context.User.Any(u => u.UserId == userId && u.Role == "Admin");
        if (isUserAdmin)
        {
           var adminLocations = _context.OfficeUser.Where(ou => ou.UserId == userId).Select(ou => ou.Office.LocNames).ToList();
           var searchQuery = _context.OfficeUsers.Where(ou => adminLocations.Contains(ou.Office.LocNames)).Select(ou => ou.User);
           if (!String.IsNullOrEmpty(searchUser))
           {
                searchQuery = searchQuery.Where(a => a.FName.Contains(searchUser));
           }
           
           var adminLocUserList  = searchQuery.ToList();
           return Ok(userList)
        }
        
       var userList = _context.OfficeUsers.Where(ou.User.FName.Contains(searchUser)).Select(ou => ou.User).ToList();
        return Ok(userList);
    }
