C#
/// <summary>
/// Create a new very complex object.
/// </summary>
/// <param name="creationOptions">Very complex creation options</param>
/// <returns>The very complex object as a data transfer object.</returns>
[HttpPost]
[Consumes("application/x-www-form-urlencoded")]
public async Task<IActionResult> CreateVeryComplexObject([FromForm] VeryComplexObjectCreationOptions creationOptions) { }
When adding the swagger services I included the documentation from both assemblies:
c#
services.AddSwaggerGen(config =>
{
    // All my other swagger configuration here...
	config.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, "MyService.API.Web.xml"));
	config.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, "MyService.API.Contracts.xml"));
});
This is on Swashbuckle 4.0.1. 
