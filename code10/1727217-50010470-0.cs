        @(Html
            .Grid(Model.Users)
            .Build(columns =>
            {
                columns.Add(model => model.username).Titled("Username");
                columns.Add(model => model.first_name).Titled("First Name");
                columns.Add(model => model.last_name).Titled("Last Name");
                columns.Add(model => model.last_login).Titled("Last Login").RenderedAs(model => model.last_login == DateTime.MinValue ? "Never" : model.last_login.ToString());
                columns.Add(model => model.banned).Titled("Banned").Encoded(false).RenderedAs(model => model.banned ? "<div>whatever goes here</div>" : "<img />");
            })
            .Filterable()
            .Sortable()
            .Pageable()
            .Css("table table-sm table-striped table-hover table-responsive")
        )    
