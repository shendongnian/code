    // So we can access the BindingTemplateSource class
    using Microsoft.Azure.WebJobs.Host.Bindings.Path;
    
    [FunctionName("ReadBlob")]
    public static async Task<string> ReadBlob(
        [ActivityTrigger] JObject eventData,
        [Blob("{data.url}", FileAccess.Read)]CloudBlockBlob blob,
        ILogger log)
    {
        // Define the pattern to match
        var blobPattern = "myContainer/{name}.{extension}";
        // Create a BindingTemplateSource from the pattern string
        var patternTemplate = BindingTemplateSource.FromString(blobPattern);
        // Use this BindingTemplateSource to create the binding data
        // This returns a IReadOnlyDictionary<string, object> with the parameters mapped
        var parameters = patternTemplate.CreateBindingData($"{blob.Container.Name}/{blob.Name}");
        // Assuming blob path was "myContainer/myBlob.png":
        // Parameters are objects so we need to ToString() them
        var name = parameters["name"].ToString(); // name == "myBlob"
        var extension = parameters["extension"].ToString(); // extension == "png"
        
        if (extension.Equals("txt", StringComparison.OrdinalIgnoreCase))
        { ... }
        else if (extension.Equals("png", StringComparison.OrdinalIgnoreCase))
        { 
            // This executes now!
        }
        else
        { ... }
    }
