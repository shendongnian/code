    var values = Bp.GetType().GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(NavigationAttribute), false).Count() != 1)
                .Select(x =>
                new
                {
                    property = x.Name,
                    value = x.GetValue(Bp, null)
                }).ToDictionary(x => x.property, y => y.value);
