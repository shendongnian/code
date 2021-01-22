[Fact]
public void Pass_Open_Connection_Without_Provider()
{
    Action action = () => {
        using (var c = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection())
        {
            c.ConnectionString = "<xxx>";
            c.Open();
        }
    };
            
    action.Should().Throw<Exception>().WithMessage("xxx");
}
**After**
[Fact]
public void Pass_Open_Connection_Without_Provider()
{
    ((Action)(() => {
        using (var c = DbProviderFactories.GetFactory("<provider>").CreateConnection())
        {
            c.ConnectionString = "<connection>";
            c.Open();
        }
    })).Should().Throw<Exception>().WithMessage("Unable to find the requested .Net Framework Data Provider.  It may not be installed.");
}
