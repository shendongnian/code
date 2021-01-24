    [Fact]
    public void RawJson()
    {
        using (var store = GetDocumentStore())
        {
            using (var session = store.OpenSession())
            {
                var json = "{ 'Name' : 'John', '@metadata' : { '@collection': 'Users' } }";
                var blittableJson = ParseJson(session.Advanced.Context, json);
                var command = new PutDocumentCommand("users/1", null, blittableJson);
                session.Advanced.RequestExecutor.Execute(command, session.Advanced.Context);
            }
            using (var session = store.OpenSession())
            {
                var user = session.Load<User>("users/1");
                Assert.Equal("John", user.Name);
            }
        }
    }
    public BlittableJsonReaderObject ParseJson(JsonOperationContext context, string json)
    {
        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
            return context.ReadForMemory(stream, "json");
        }
    }
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
