    <% using (Html.BeginForm()) { %>
        <%= Html.Grid<Product>(Model)
            .Columns(column => {
                column.For(x => x.Id);
                column.For(x => x.Name);
                column.For(x => x.IsInStock).Partial("~/Views/Home/IsInStock.ascx");
            }
        ) %>
        <input type="submit" value="OK" />
    <% } %>
