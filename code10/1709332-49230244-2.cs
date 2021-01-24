    var listOfExampleEntity = new List<ExampleEntity>()
            {
                new ExampleEntity()
                {
                    Date = new DateTime(2018, 10, 03, 3, 40, 00),
                    Val =2
                },
                new ExampleEntity()
                {
                    Date = new DateTime(2018, 10, 03, 4, 40, 00),
                    Val =2
                },new ExampleEntity()
                {
                    Date = new DateTime(2018, 11, 03, 5, 40, 00),
                    Val =5
                },new ExampleEntity()
                {
                    Date = new DateTime(2018, 10, 03, 3, 40, 00),
                    Val =2
                },new ExampleEntity()
                {
                    Date = new DateTime(2018, 11, 03, 7, 40, 00),
                    Val =3
                },new ExampleEntity()
                {
                    Date = new DateTime(2018, 11, 03, 8, 40, 00),
                    Val =4
                },
            };
            var temp = listOfExampleEntity.GroupBy(
                        p => p.Date.Date,
                        p => p.Val,
                        (date, val) => new { Date = date, Value = val.ToList().Last() });
