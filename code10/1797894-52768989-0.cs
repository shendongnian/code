        static void Main(string[] args) {
            //
            // Table definition:
            //
            // CREATE TABLE dbo.Test(Id INT IDENTITY(1, 1) NOT NULL, Content VARCHAR(MAX) NULL);
            //
            // Create some dummy data.
            var table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(System.Int32)));
            table.Columns.Add(new DataColumn("Content", typeof(System.String)));
            var row = table.NewRow();
            row["Id"] = 12345;
            row["Content"] = "Testing";
            table.Rows.Add(row);
            // Bulk copy it in.
            using (var connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Sandbox;Integrated Security=SSPI"))
            using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, null)) {
                connection.Open();
                bulkCopy.DestinationTableName = "dbo.Test";
                bulkCopy.WriteToServer(table);
            };
            //
            // To check results:
            //
            // SELECT * FROM dbo.Test;
            //
        }
