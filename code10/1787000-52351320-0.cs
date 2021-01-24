    var query =
                (from t in result
                 group t.TableName by t.TableName
                into tn
                 select new Table
                 {
                     Name = tn.Key,
                     Schema = (from s in result where s.TableName == tn.Key select s.TableSchema).First(),
                     Columns = (from c in result
                                where c.TableName == tn.Key
                                select new Column
                                {
                                    Name = c.ColumnName,
                                    IsPrimaryKey = c.IsPrimaryKey
                                }).ToList()
                 });
