    using (SiteDataContext context = SiteDataContext.Create())
    {
        context.Connection.Open();
        context.ExecuteStoreCommand("SET IDENTITY_INSERT [EnumValue] ON");
        var val = new EnumValue()
        {
            ID = 2000000,
            Value = "just a test",
        };
        context.AddToEnumValues(val);
        context.SaveChanges();
        context.ExecuteStoreCommand("SET IDENTITY_INSERT [EnumValue] OFF");
    }
