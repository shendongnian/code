    public IEnumerable<SelectListItem> RolesToUser { get; set; }
    ...
    public void OnGet()
    {
        var roles = _roleManager.Roles.ToList();
        RolesToUser = roles.Select(a => new SelectListItem()
        {
            Value = a.Id.ToString(),
            Text = a.Name
        }).ToList();
    }
