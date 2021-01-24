public class CustomID
{
    public string CountryCode { get; set; }
    public long KeywordId { get; set; }
    public string Name { get; set; }
}
public class Keyword
{
    [BsonId]
    public CustomID Id { get; set; }
    public List<Category> Categories { get; set; }
}
public class Category
{
    [BsonId]
    public long Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
}
internal class Program
{
    public static IMongoDatabase MongoDatabase { get; private set; }
    public static async Task Main()
    {
        var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };
        ConventionRegistry.Register(
            "CustomConventionPack",
            conventionPack,
            t => true);
        var client = new MongoClient();
        MongoDatabase = client.GetDatabase("SO");
        var ret = await GetKeywords(new List<long> {1L, 2L}, "HU-hu");
        // ret is A and B. C is filtered out because no category id of 1L or 2L, D is not HU-hu
    }
    public static async Task<List<Keyword>> GetKeywords(List<long> keywordCatIds, string countryCode)
    {
        var mongoCollection = MongoDatabase.GetCollection<Keyword>("keywords");
        // be ware! removes all elements. For debug purposes uncomment>
        //await mongoCollection.DeleteManyAsync(FilterDefinition<Keyword>.Empty);
        await mongoCollection.InsertManyAsync(new[]
        {
            new Keyword
            {
                Categories = new List<Category>
                {
                    new Category {Id = 1L, Name = "CatA", Position = 1},
                    new Category {Id = 3L, Name = "CatC", Position = 3}
                },
                Id = new CustomID
                {
                    CountryCode = "HU-hu",
                    KeywordId = 1,
                    Name = "A"
                }
            },
            new Keyword
            {
                Categories = new List<Category>
                {
                    new Category {Id = 2L, Name = "CatB", Position = 2}
                },
                Id = new CustomID
                {
                    CountryCode = "HU-hu",
                    KeywordId = 2,
                    Name = "B"
                }
            },
            new Keyword
            {
                Categories = new List<Category>
                {
                    new Category {Id = 3L, Name = "CatB", Position = 2}
                },
                Id = new CustomID
                {
                    CountryCode = "HU-hu",
                    KeywordId = 3,
                    Name = "C"
                }
            },
            new Keyword
            {
                Categories = new List<Category>
                {
                    new Category {Id = 1L, Name = "CatA", Position = 1}
                },
                Id = new CustomID
                {
                    CountryCode = "EN-en",
                    KeywordId = 1,
                    Name = "EN-A"
                }
            }
        });
        var keywordFilter = Builders<Keyword>.Filter;
        var mongoFilter =
            keywordFilter.ElemMatch(c => c.Categories, category => keywordCatIds.Contains(category.Id)) &
            // I have doubts if it should be same elem match like in categories.
            keywordFilter.Eq(k => k.Id.CountryCode, countryCode);
        return await mongoCollection.Find(mongoFilter).ToListAsync();
    }
}
