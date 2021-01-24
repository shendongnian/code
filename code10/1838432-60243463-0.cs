    public class Program
    {
    	internal const string BaseAddress = "http://localhost:81/";
    	internal const string ProdBaseAddress = "http://localhost:5001/";
    	public static async Task Main(string[] args)
    	{
    		var builder = WebAssemblyHostBuilder.CreateDefault(args);
    		builder.RootComponents.Add<App>("app");
    
    		var host = builder.Build();
    		var httpClient = host.Services.GetRequiredService<HttpClient>();
    #if DEBUG
    		httpClient.BaseAddress = new Uri(BaseAddress);
    #else
    		httpClient.BaseAddress = new Uri(ProdBaseAddress);
    #endif
    
    
    		Console.WriteLine($"Set BaseAddress: {BaseAddress}");
    		await host.RunAsync();
    	}
    }
