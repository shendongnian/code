    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(UserViewModel postData) {
         if (!ModelState.IsValid) {
             return View("Edit", postData);
         }
    
         var command = Mapper.Map<EditUserCommand>(postData);
         var updatedUserDto = _userService.EditUser(command);
         
         var updatedUserViewModel = Mapper.Map<UserViewModel>(updatedUserDto);
         return View("Show", updatedUserViewModel);
    }
