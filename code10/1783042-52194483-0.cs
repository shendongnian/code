    string voiceRoleId = (await roleManager.FindByNameAsync("Voice")).Id;
    var result = await dbContext.ChatMessages.AsNoTracking()
        .Where(chm => chm.TimePosted.Date == someDateTime.Date).OrderBy(chm => chm.TimePosted)
        .GroupJoin(
            dbContext.UserRoles.Where(ur => ur.RoleId == voiceRoleId),
            chm => chm.AuthorId, r => r.UserId,
            (chm, rs) => new { Message = chm, IsVoice = rs.Any() }
        ).ToListAsync();
