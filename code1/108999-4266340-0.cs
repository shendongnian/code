    [TestMethod]
    public void CanMapItem()
    {
        var p1 = new ItemPicture { Filename = "test.jpg", Title = "Test title", PrimaryPicture = true};
        var p2 =  new ItemPicture { Filename = "test2.jpg", Title = "Test title 2" };
        using (var tx = Session.BeginTransaction())
        {
            Session.Save(p1);
            Session.Save(p2);
        };
        new PersistenceSpecification<Item>(Session)
            .CheckProperty(i => i.Title, "Test item")
            .CheckProperty(i => i.Description, "Test description")
            .CheckProperty(i => i.SalesPrice, (decimal)0.0)
            .CheckList(i => i.ItemPictures, new List<ItemPicture> {p1, p2});
            .VerifyTheMappings();
    }
