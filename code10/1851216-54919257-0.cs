`
namespace GregThomas.MyApp.DataAccess.Common
{
    public interface ISprocketRepository
    {
        Task<IEnumerable<Sprocket>> GetAllAsync();
    }
    public class Sprocket
    {
        // All the properties of a sprocket would be here
    }
}
`
You'd then have separate assemblies for each of the database providers that you wanted to support for example, in the assembly `GregThomas.MyApp.DataAccess.SqlServer`:
`
namespace GregThomas.MyApp.DataAccess.SqlServer
{
    public sealed class SprocketRepository : ISprocketRepository
    {
        Task<IEnumerable<Sprocket>> ISprocketRepository.GetAllAsync()
        {
            // Code to retrieve sprockets from a SQL Server database here
        }
    }
}
`
Each of your database specific assemblies would reference the *.Common* assembly in order to be able to implement the appropriate interfaces and to access the models.
