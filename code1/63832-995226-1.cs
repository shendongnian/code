    <%= Html.ListBox("users", Model.UsersGrossList.Select(
        x => new SelectListItem {
            Text = x.Name,
            Value = x.Id,
            Selected = Model.UsersSelectedList.Any(y => y.Id == x.Id)
        }
    ) %>
