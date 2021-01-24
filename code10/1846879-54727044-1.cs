`C#
public static async Task<string> Get(string requestUri)
{
    try
    {
        return await GetStringAsync(requestUri);
    }
    catch (Exception exception)  // Or, specify the expected exception type
    {
        Console.WriteLine(exception);
        throw;  // can be caught in the calling code
    }
}
`
