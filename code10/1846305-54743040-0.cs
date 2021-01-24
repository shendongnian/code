    //post register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountVM obj)
        {
            if(ModelState.IsValid)
            {
                // insert Data into user variable array from obj viewmodel
                var user = new user()
                {
                    user_email = obj.user_email,
                    user_full_name = obj.user_full_name,
                    user_password = obj.user_password,
                    user_phone = obj.user_phone,
                    user_mobile = obj.user_mobile,
                    country_id = obj.country_id,
                    city_id = obj.city_id
                };
                AccountDb.users.Add(user);
                                
                // insert Data into user_has_role variable array from obj viewmodel
                foreach(var item in obj.selectedRoleList)
                {
                    int id = Convert.ToInt32(item);
                    user_role _user_role = AccountDb.user_role.FirstOrDefault(r => r.user_role_id == id);
                    _user_role.users.Add(user);
                    user.user_role.Add(_user_role);
                }
                if (AccountDb.SaveChanges() > 0)
                {
                    TempData["errorMsg"] = "save";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMsg"] = "queryError";
                    ViewBag.country_id = new SelectList(AccountDb.countries, "country_id", "country_name");
                    AccountVM objRole = new AccountVM();
                    objRole.getRoleList = AccountDb.user_role.ToList();
                    return View(objRole);
                }
            }
            else
            {
                TempData["errorMsg"] = "modelError";
                ViewBag.country_id = new SelectList(AccountDb.countries, "country_id", "country_name");
                AccountVM objRole = new AccountVM();
                objRole.getRoleList = AccountDb.user_role.ToList();
                return View(objRole);
            }
        }
