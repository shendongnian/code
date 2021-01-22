    var linqsession = session.Linq<FeedItem>();
    linqsession.QueryOptions.RegisterCustomAction(c => c.SetResultTransformer(new DistinctRootEntityResultTransformer()));
    var feedItemQuery = from ad in linqsession.Expand("Ads")
                        where ad.Id == Id
                        select ad
