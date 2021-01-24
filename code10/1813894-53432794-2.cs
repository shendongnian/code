    var model = new Model
    {
        Name = "Joe Bloggs",
        BillingAddress = new Address
        {
            Line1 = "Line 1",
            Line2 = "Line 1",
            Line3 = "Line 1",
            PostalCode = "ABCDEF",
            Latitude = 1232,
            Longitude = 4321,
            Unit = "A Unit"
        },
        MailingAddress = new Address
        {
            Line1 = "M Line 1",
            Line2 = "M Line 1",
            Line3 = "M Line 1",
            PostalCode = "MMFDS",
            Latitude = 6543,
            Longitude = 78990,
            Unit = "M Unit"
        },
    };
    var viewModel = mapper.Map<ViewModel>(model);
    var newModel = mapper.Map<Model>(viewModel);
