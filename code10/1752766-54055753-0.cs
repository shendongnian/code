    [HttpPost]
        public async Task<IActionResult> OnPostGetPagination()
        {
            #region pagination
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // Skip number of Rows count  
            var start = Request.Form["start"].FirstOrDefault();
            // Paging Length 10,20  
            var length = Request.Form["length"].FirstOrDefault();
            // Sort Column Name  
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            // Sort Column Direction (asc, desc)  
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // Search Value from (Search box)  
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            //Paging Size (10, 20, 50,100)  
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            #endregion
             
            var users = await _userManager.Users.Include(x => x.staticCode).Skip(skip).Take(pageSize).ToListAsync();
            InputModel inputModel = new InputModel();
            foreach (var v in users)
            {
                inputModel = new InputModel();
                var roles = await _userManager.GetRolesAsync(v);
                inputModel.Email = v.UserName;
                inputModel.role = "";
                foreach (var r in roles)
                {
                    if (!inputModel.role.Contains(","))
                    {
                        inputModel.role = r;
                    }
                    else
                    {
                        inputModel.role = "," + r;
                    }
                }
                Input2.Add(inputModel);
            }
            if (searchValue != string.Empty)
            {
                Input2 = Input2.Where(x => x.Email.Contains(searchValue) || x.role.Contains(searchValue)).ToList();
            }
            //total number of rows counts   
            recordsTotal = Input2.Count;
            var json = new JsonResult(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = Input2 });
            return json;
        }
