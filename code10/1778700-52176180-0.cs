    [Test]
    public async Task MultipleSpResultsWithDapper()
    {
        // Act
        using (var conn = new SqlConnection("Data Source=YourDatabase"))
        {
            await conn.OpenAsync();
            var result = await conn.QueryMultipleAsync(
                "YourStoredProcedureName",
                new { param1 = 1, param2 = 2 }, 
                null, null, CommandType.StoredProcedure);
            // read as IEnumerable<dynamic>
            var table1 = await result.ReadAsync();
            var table2 = await result.ReadAsync();
            // read as typed IEnumerable
            var table3 = await result.ReadAsync<Table1>();
            var table4 = await result.ReadAsync<Table2>();
                
            //Assert
            Assert.IsNotEmpty(table1);
            Assert.IsNotEmpty(table2);
            Assert.IsNotEmpty(table3);
            Assert.IsNotEmpty(table4);
        }
    }
