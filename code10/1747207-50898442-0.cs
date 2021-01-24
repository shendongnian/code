    const string sqlTemplate = "SELECT /**select**/ FROM Sale /**where**/ /**orderby**/";
            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(sqlTemplate);
            sqlBuilder.Select("*");
            for (var i = 0; i < filterRanges.Count; i++)
            {
                sqlBuilder.Where($"{filterRanges[i].ColumnName} = @columnValue", new { columnValue = filterRanges[i].FromValue });
            }
            using (var conn = OpenConnection())
            {
                return conn.Query<Sale>(template.RawSql, template.Parameters).AsList();
            }
