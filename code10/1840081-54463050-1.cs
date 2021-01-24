    int siteID = 829;
    List<int> itemIdList = new List<int>() { 939, 940, 950 };
    SiteItemOnHand siAlias = null;
    var subQuery = QueryOver.Of<SiteItemOnHand>()
		.Where(x => x.Businessunitid == siAlias.Businessunitid)
		.And(x => x.ItemID == siAlias.ItemID)
		.Select(Projections.Max<SiteItemOnHand>(y => y.lastmodifiedtimestamp));
    var siteItems = Session.QueryOver<SiteItemOnHand>(() => siAlias)
        .Where(x => x.Businessunitid == siteID)
        .AndRestrictionOn(x => x.ItemID).IsIn(itemIdList.ToArray())
        .WithSubquery.Where(x => siAlias.lastmodifiedtimestamp == subQuery.As<DateTime>())
        .List();
