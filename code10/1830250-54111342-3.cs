    using System.Data;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Threading.Tasks;
    public class Table1Business
    {
        public async Task<DataTable> Search(string name,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var connection = new SqlConnection(@"Your connection string"))
            using (var command = new SqlCommand("WAITFOR DELAY '00:00:10'; " +
                "SELECT TOP 10 [Id], [Name] " +
                "FROM [Table1] WHERE [Name] LIKE '%' + @Name + '%'", connection))
            {
                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Name", typeof(string));
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
                await connection.OpenAsync(cancellationToken);
                var reader = await command.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    object[] values = new object[2];
                    reader.GetValues(values);
                    table.Rows.Add(values);
                }
                return table;
            }
        }
    }
