public BoolQuery GetBoolQuery(RecommenderQueryFields shoulds, RecommenderQueryFields musts,
    RecommenderQueryFields mustNots)
{
    var boolQuery = new BoolQuery();
    boolQuery.Should = GetQueryContainers(shoulds);
    boolQuery.Must = GetQueryContainers(musts);
    boolQuery.MustNot = GetQueryContainers(mustNots);
    return boolQuery;
}
You are exposing a `public` method which you are not intending for use, only for testing.
But you can then assert on `boolQuery` like this:
[Test]
public void GetRecommendations_CallsElasticSearch()
{
    // Arrange
    var elasticClient = Substitute.For<IElasticClient>();
    var sut = new Recommender(elasticClient);
    // Act
    var boolQuery = sut.GetBoolQuery(new RecommenderQueryFields{BlackListedFor = new List<string>{"asdf"}}, null, null);
    // Assert
    Assert.AreEqual(1, boolQuery.Should.Count());
}
In `boolQuery.Should` is a list of `QueryContainer` which are not testable because it is generated with lambdas aswell. While better than nothing, it is still not a clean way to test NEST.
