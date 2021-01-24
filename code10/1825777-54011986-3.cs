    private ApplicationDbContext db = new ApplicationDbContext(); 
    public async Task<ActionResult> Index(int? SelectedSuperior)
            {
                var superiors = db.Users.OrderBy(s => s.FirstName).ToList();
                ViewBag.SelectedSuperior = new SelectList(superiors, "Id", "FullName", SelectedSuperior);
                int superiorID = SelectedSuperior.GetValueOrDefault();
    
                IQueryable<ApplicationUser> users = db.Users
                    .Where(c => !SelectedSuperior.HasValue || c.SuperiorID == superiorID)
                    .OrderBy(d => d.Id)
                    .Include(d => d.Superior);
                var sql = users.ToString();
    
                return View(await UserManager.Users.ToListAsync());
            } 
    public ActionResult Create()
            {
                PopulateSuperiorsDropDownList();
                return View();
            } 
    public async Task<ActionResult> Create(RegisterViewModel userViewModel)
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser
                    {
                        FirstName = userViewModel.FirstName,
                        LastName = userViewModel.LastName,
                        SuperiorID = userViewModel.SuperiorID,
                    };
    
                }
                PopulateSuperiorsDropDownList(userViewModel.SuperiorID);
                return View();
            } 
    public async Task<ActionResult> Edit(int id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var user = await UserManager.FindByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
    
                var model = new EditUserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    SuperiorID = user.SuperiorID,
                };
                PopulateSuperiorsDropDownList(user.SuperiorID);
                return View(model);
            } 
    public async Task<ActionResult> Edit([Bind(Include = "Email,Id,FirstName,LastName,SuperiorID")] EditUserViewModel editUser)
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindByIdAsync(editUser.Id);
                    if (user == null)
                    {
                        return HttpNotFound();
                    }
    
                    // Update the User:
                    user.Email = editUser.Email;
                    user.FirstName = editUser.FirstName;
                    user.LastName = editUser.LastName;
                    user.SuperiorID = editUser.SuperiorID;
                }
                ModelState.AddModelError("", "Something failed.");
                PopulateSuperiorsDropDownList(editUser.SuperiorID);
                return View();
            } 
    private void PopulateSuperiorsDropDownList(object selectedSuperior = null)
            {
                var superiorsQuery = from s in db.Users
                                       orderby s.FirstName + " " + s.LastName
                                       select s;
                ViewBag.SuperiorID = new SelectList(superiorsQuery, "Id", "FullName", selectedSuperior);
            } 
