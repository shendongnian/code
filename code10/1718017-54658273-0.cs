    var tbl = new DataTable();
               tbl.Columns.Add("id", typeof(string));
            foreach (var item in imageChunkRequest.ChunkNames)
            {
                   tbl.Rows.Add(item);
            }
     SqlParameter Parameter = new SqlParameter();
                    Parameter.ParameterName = "@udt";
                    Parameter.SqlDbType = SqlDbType.Structured;
                    Parameter.Value = tbl;
                    Parameter.TypeName = "dbo.StringList";
        
         _dbContext.Set<T>().FromSql("EXEC dbo.FindChunks @udt",Parameter);
