    <%= Html.DropDownListFor(
        model => model.Bikes,
        new SelectList(Model.Bikes.Select(x => new {
            Id = x.Id,
            Name = Url.Action("Details", "Bike", new { bikeId = x.ID })
        }), "Id", "Name", Model.ID)
    )%>
