?:
    <%= Html.ListBox("users", Model.UsersGrossList.Select(
        x => new SelectListItem {
            Text = x.Name,
            Value = x.Value,
            Selected = Model.UsersSelectedList.Any(y => y.Value == x.Value)
        }
    ) %>
