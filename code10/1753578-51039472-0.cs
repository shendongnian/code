    list.Where(x => x.GetType()
                .GetProperties()
                .Any(p =>
                {
                    var value = p.GetValue(x);
                    return value != null && value.ToString().Contains("some string");
                }));
