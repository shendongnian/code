    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host.Bindings.Runtime;
    public static async Task Run(string input, Binder binder)
    {
        using (var writer = await binder.BindAsync<TextWriter>(new BlobAttribute("samples-output/path")))
        {
            writer.Write("Hello World!!");
        }
    }
