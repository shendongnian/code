     var boolQuery = new BoolQueryDescriptor<AttractionDocument>();
            if (request.AddDateFilter)
            {
                boolQuery.Should(mn => mn.DateRange(d => d.Field(f => f.AvailableTo).GreaterThanOrEquals(DateTime.Now)));
            }
            //https://github.com/elastic/elasticsearch-net/issues/2570 must is not additive, we cannot split out query as before it all has to be one big one
            boolQuery.Must(
                mn => AddRegionQuery(permissions, mn),
                mn => AddOffersQuery(permissions, mn),
                mn => request.AddDateFilter ? mn.DateRange(d => d.Field(f => f.AvailableFrom).LessThanOrEquals(DateTime.Now)) : mn,
                mn => AddGenresQuery(genres, mn)
             );
