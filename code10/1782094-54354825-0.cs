using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DiagnosticAdapter;
namespace Example
{
    public class CommandInterceptor
    {
        [DiagnosticName("Microsoft.EntityFrameworkCore.Database.Command.CommandExecuting")]
        public void OnCommandExecuting(DbCommand command, DbCommandMethod executeMethod, Guid commandId, Guid connectionId, bool async, DateTimeOffset startTime)
        {
            var secondaryDatabaseName = "MyOtherDatabase";
            var schemaName = "dbo";
            var tableName = "Stock";
            command.CommandText = command.CommandText.Replace($" [{tableName}]", $" [{schemaName}].[{tableName}]")
                                                     .Replace($" [{schemaName}].[{tableName}]", $" [{secondaryDatabaseName}].[{schemaName}].[{tableName}]");
        }
    }
}
Replace 'MyOtherDatabase', 'dbo' and 'Stock' with your Database name, table schema and table name, maybe from a config etc. 
Then attach that interceptor to your context.
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
 
var context = new MultipleDatabasesExampleDbContext(optionsBuilder.Options);
// Add interceptor to switch between databases
var listener = context.GetService<DiagnosticSource>();
(listener as DiagnosticListener).SubscribeWithAdapter(new CommandInterceptor());
In my case I put the above in MultipleDatabasesExampleDbContextFactory method.
Now you can just use the context as if you were referencing one database.
