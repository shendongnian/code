     Expression<Func<T, string, PropertyInfo>> expression = (obj, str) => obj.GetType().GetProperty(obj
                    .GetType().GetProperties().ToList()
                    .Find(property => property.Name
                    .ToLower() == str
                    .ToLower()).Name.ToString());
                     var Obj = expression.Compile()(rowsData.FirstOrDefault(), sortIndex);
