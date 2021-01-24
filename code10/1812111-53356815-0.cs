    var allTokens = new List<AccessToken>
        {
            new Domain.Models.AccessToken {ApplicationName = "Test", ExpirationDate = DateTime.Now.AddDays(100), Id = new Guid("943e31bd-7c91-44bf-9ee2-3366c9f5010c"), Token = "aaaBBB111"},
            new Domain.Models.AccessToken {ApplicationName = "Test 2", ExpirationDate = DateTime.Now.AddDays(50), Id = new Guid("cc1cec9b-7de6-46e7-8069-5681c8d2d331"), Token = "xxxYYY777"},
            new Domain.Models.AccessToken {ApplicationName = "Test 3", ExpirationDate = DateTime.Now.AddDays(10), Id = new Guid("da5343da-e2c4-477c-b3ed-b60133512f5d"), Token = "cccDDD888"},
            new Domain.Models.AccessToken {ApplicationName = "Test 3", ExpirationDate = DateTime.Now.AddDays(365), Id = new Guid("7d7556d8-e194-43be-89ce-0961fc94ebd4"), Token = "eeeFFF999"},
            new Domain.Models.AccessToken {ApplicationName = "Test 4", ExpirationDate = DateTime.Now.AddDays(-1), Id = new Guid("0de8a36f-a249-4df1-a5c5-fbaf26e32bb2"), Token = "jjjKKK444"},
        };
    var expiringThresholdInDays = 15;
    var expirationDeadLine = System.DateTime.Now.AddDays(expiringThresholdInDays);
    var expiringTokens = allTokens.GroupBy(a => a.ApplicationName).Where(b => b.OrderByDescending(x => x.ExpirationDate).FirstOrDefault().ExpirationDate < expirationDeadLine);
