    var viewModel = new AdminViewModel();
    SelectListItem item;
    var userType = _context.UserTypes.ToList();
    foreach(var uType in userType)
      {
       item = new SelectListItem();
       item.Text = userType.userTypeName;
       item.Value = userType.userTypeID;
       if (item.Text == "Caregiver") // or any logic
         {
           item.Selected = true;
         }
         viewModel.UserTypes.Add(item);
       }
           
     return View(viewModel);
