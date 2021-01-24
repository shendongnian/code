    [HttpPost]
        public async Task<IActionResult> OnPostGetPagination()
        {
           
             
            var users = await _userManager.Users.ToListAsync();
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
          
            
        }
