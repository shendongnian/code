csharp
public class Response
{
    [JsonProperty("container")]
    public DataContainer Container { get; set; }
}
public class DataContainer
{
    [JsonProperty("data")]
    public Data Data { get; set; }
}
public class Data
{
    [JsonProperty("ids")]
    public IList<string> Ids { get; set; }
}
And then I have a Refit API like this instead:
csharp
public interface ISomeService
{
    [Get("/someurl/{thing}.json")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("use extension " + nameof(ISomeService) + "." + nameof(SomeServiceExtensions.GetThingAsync))]
    Task<Response> _GetThingAsync(string thing);
}
I can just define an extension method like this, and use this one instead of the API exposed by the Refit service:
csharp
#pragma warning disable 612, 618
public static class SomeServiceExtensions
{
    public static Task<Data> GetThingAsync(this ISomeService service, string thing)
    {
        var response = await service._GetThingAsync(thing);
        return response.Container.Data.Ids;
    }
}
This way, whenever I call the `GetThingAsync` API, I'm actually using the extension method that can take care of all the additional deserialization for me.
