            var query = dt.AsEnumerable()
                .OrderBy(dr => dr.ItemArray[0] as string)
                .Distinct(DataRowComparer.Default).Select(dr => dr.ItemArray[0]);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
