    var client = new ElasticClient();
    var searchRequest = new SearchRequest<ProductType>
    {
        Query = new FunctionScoreQuery()
        {
            Query = new MatchAllQuery { },
            Boost = 5,
            Functions = new List<IScoreFunction>
            {
                new RandomScoreFunction
                {
                    Filter = new MatchQuery
                    {
                        Field = "test",
                        Query = "bar"
                    },
                    Weight = 23
                },
                new WeightFunction
                {
                    Filter = new MatchQuery
                    {
                        Field = "test",
                        Query = "cat"
                    },
                    Weight = 42
                }
            },
            MaxBoost = 42,
            ScoreMode = FunctionScoreMode.Max,
            BoostMode = FunctionBoostMode.Multiply,
            MinScore = 42
        }
    };
    var searchResponse = client.Search<ProductType>(searchRequest);
