    public IActionResult GetByAppId(string Id)
    {
        return new JsonResult(_db.Applications
            .Select(a => new
            {
                a.Id,
                a.AppId,
                a.Name,
                AppVersion = a.AppVersion.Replace(a.Name, "")
            })
            .Where(a => a.Id == Id)
            .SingleOrDefault()
        );
    }
