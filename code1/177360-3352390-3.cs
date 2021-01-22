    <%= Html.DropDownListFor(
        model => model.SelectedBikeValue,
        Model.Bikes.Select(
            x => new SelectListItem {
                     Text = x.Name,
                     Value = Url.Action("Details", "Bike", new { bikeId = x.ID }),
                     Selected = x.ID == Model.ID,
            }
    )) %>
