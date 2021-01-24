    var request = await graphClient.Sites[siteId].Lists[listId].Items.Request().Filter("fields/CustomerId eq 123").Expand(item => item.DriveItem).GetAsync();
    foreach (var item in request)
    {
        Console.WriteLine(item.DriveItem.WebUrl);
    }
