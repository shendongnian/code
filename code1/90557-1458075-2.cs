            var row = Expression.Parameter(typeof(Data), "row");
            Expression body = null;
            Expression testVal = Expression.Constant(query, typeof(string));
            foreach (string columnName in columnNames)
            {
                Expression col = Expression.PropertyOrField(row, columnName);
                Expression colString = col.Type == typeof(string)
                    ? col : Expression.Call(col, "ToString", null, null);
                Expression colTest = Expression.Call(
                    colString, "Contains", null, testVal);
                if (col.Type.IsClass)
                {
                    colTest = Expression.AndAlso(
                        Expression.NotEqual(
                            col,
                            Expression.Constant(null, typeof(string))
                        ),
                        colTest
                    );
                }
                else if (Nullable.GetUnderlyingType(col.Type) != null)
                { // Nullable<T>
                    colTest = Expression.AndAlso(
                        Expression.Property(col, "HasValue"),
                        colTest
                    );
                }
                body = body == null ? colTest : Expression.OrElse(body, colTest);
            }
            Expression<Func<Data, bool>> predicate
                = body == null ? x => false : Expression.Lambda<Func<Data, bool>>(
                      body, row);
            var data = new[] {
                new Data { Name = "fred2008", DoB = null},
                new Data { Name = "barney", DoB = null},
                new Data { Name = null, DoB = DateTime.Today},
                new Data { Name = null, DoB = new DateTime(2008,1,2)}
            };
            foreach (Data x in data.AsQueryable().Where(predicate))
            {
                Console.WriteLine(x.Name + " / " + x.DoB);
            }
