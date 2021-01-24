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
# Edit
@Russ Cam in the comment has mentioned the `IQueryContainer` and `QueryVisitor`
What I've got:
[Test]
public void test()
{
    // Arrange
    var fieldValue = "asdf";
    var elasticClient = Substitute.For<IElasticClient>();
    var sut = new Recommender(elasticClient);
    // Act
    var boolQuery = sut.GetBoolQuery(new RecommenderQueryFields { BlackListedFor = new List<string> { fieldValue } }, null, null);
    // Assert
    IQueryContainer qc = boolQuery.Should.First(); // Cast to IQueryContainer
    Assert.AreEqual(fieldValue, qc.Match.Query); // Assert value
    // Get "field name"
    var queryVisitor = new QueryVisitor();
    var prettyVisitor = new DslPrettyPrintVisitor(new ConnectionSettings(new InMemoryConnection()));
    qc.Accept(queryVisitor);
    qc.Accept(prettyVisitor);
    Assert.AreEqual(0, queryVisitor.Depth);
    Assert.AreEqual(VisitorScope.Query, queryVisitor.Scope);
    Assert.AreEqual("query: match (field: blacklistedfor.keyword)\r\n", prettyVisitor.PrettyPrint);
}
The value of the field can be accessed via `IQueryContainer`. 
I tried the `QueryVisitor` and the `DslPrettyPrintVisitor`. The first one doesn't provide any useful information. It has 0 depth and it is a Query? I already know that. With the second one I can assert some additional information, like the field name (blacklistedfor) and the suffix (keyword).
Not perfect to assert on the string representation, but better than nothing.
