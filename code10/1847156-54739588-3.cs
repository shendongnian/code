csharp
interface IFileGeneratorFactory
{
    // I used int because it's in your example code, but an enum would be a stronger contract
    IGenerateFile GetFileGenerator(int userInput);
}
and the implementation like:
csharp
class FileGeneratorFactory : IFileGeneratorFactory
{
    readonly IServiceProvider serviceProvider;
    public FileGeneratorFactory(IServiceProvider serviceProvider)
        => this.serviceProvider = serviceProvider;
    public IGenerateFile GetFileGenerator(int userInput)
    {
        switch (userInput)
        {
            // The Factory has explicit knowledge of the different generator types,
            // but returns them using a common interface. The consumer remains
            // unconcerned with which exact implementation it's using.
            case 1:
                return serviceProvider.GetService<GenerateCsv>();
            case 2:
                return serviceProvider.GetService<GenerateTxt>();
            default:
                throw new InvalidOperationException($"No generator available for user input {userInput}");
        }
    }
}
Register the classes like:
csharp
var services = new ServiceCollection()
    .AddTransient<GenerateCsv>()
    .AddTransient<GenerateTxt>()
    .AddTransient<IFileGeneratorFactory, FileGeneratorFactory>();
Then, consume like:
csharp
IGenerateFile fileGenerator = service
    .GetService<IFileGeneratorFactory>()
    .GetFileGenerator(userInput);
string result = fileGenerator.GenerateFile();
This factory implementation is pretty simplistic. I wrote it that way to keep it approachable, but I highly recommend looking at the more elegant examples in the [Simple Injector docs](https://simpleinjector.readthedocs.io/en/latest/howto.html#resolve-instances-by-key). Since those examples target Simple Injector, and not ASP.Net DI, they might need some tweaking to work for you--but the basic patterns should work for any DI framework.
