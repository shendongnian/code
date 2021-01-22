In a similar case I stored the connection string for the dataset in a settings file / app.config (default behaviour in Visual Studio when creating a dataset) with integrated security to a local development database. In order to be able to access this from external projects, I changed the settings file to be public instead of the default internal (in the visual designer). This resulted in code like (in Properties\Settings.Designer.cs):
public sealed partial class Settings
{
    [...]
    [global::System.Configuration.DefaultSettingValueAttribute
            ("Data Source=.;Initial Catalog=MyDb;Integrated Security=True;")]
    public string MyConnectionString
    {
        get
        {
            return ((string)(this["MyConnectionString"]));
        }
    }
}
