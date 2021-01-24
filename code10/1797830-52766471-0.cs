    from ua in db.FooBar_UserAuth
    join ra in db.FooBar_RoomAuth
        on new { ua.FooBar_Authorization.AuthId, IsActive = true }
        equals new { ra.AuthId, ra.IsActive } into raJoin
    from ra in raJoin.DefaultIfEmpty()
    join ri in db.Room_Inventory
        on new { ra.RmId, IsActive = true }
        equals new { RmId = ri.RMID, ri.IsActive } into riJoin
    from ri in riJoin.DefaultIfEmpty()
    where
        ua.FooBar_Authorization.IsActive &&
        ua.IsPi == true &&
        ua.FooBar_User.IsActive &&
        ua.FooBar_User.UserId == 10
    group new { ua.FooBar_Authorization, ua.FooBar_Authorization.FooBar_AuthType, ra } by new
    {
        AuthId = (int?)ua.FooBar_Authorization.AuthId,
        ua.FooBar_Authorization.FooBar_AuthType.AuthTypeAbbr,
        ua.FooBar_Authorization.ExpirationDate
    } into g
    select new
    {
        AuthId = g.Key.AuthId.Value,
        RmCnt = g.Count(p => p.ra != null),
        AuthType = g.Key.AuthTypeAbbr,
        ExpirationDate = g.Key.ExpirationDate
    }
