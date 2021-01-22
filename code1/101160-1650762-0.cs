        public void Test()
        {
            IEnumerable<Data> list = new List<Data>
            {
                new Data{Name = "A", Age=10},
                new Data{Name = "A", Age=12},
                new Data{Name = "B", Age=20},
                new Data{Name= "C", Age=15}
            };
   
            var data = Expression.Parameter(typeof(IEnumerable<Data>), "data");
            var arg = Expression.Parameter(typeof(Data), "arg");
            var nameProperty = Expression.PropertyOrField(arg, "Name");
            var lambda = Expression.Lambda<Func<Data, string>>(nameProperty, arg);
            var expression = Expression.Call(
                typeof(Enumerable),
                "GroupBy", 
                new Type[] { typeof(Data), typeof(string) },
                data,
                lambda);
            //expected = {data.GroupBy(arg => arg.Name)}
        }
