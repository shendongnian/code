    var usersGrossList = ...
    var model = ...
    var viewModel = new ViewModel {
        YourModel = model;
        Users = usersGrossList.Select(
            x => new SelectListItem {
                Text = x.Name,
                Value = x.Id,
                Selected = model.UsersSelectedList.Any(y => y.Id == x.Id)
            }
        }
