            var orderedList = lista.GroupBy(x => x.Id)
                                   .Where(x => x.Any(y => y.Deleted == 1))
                                   .Select(x => new Oggetto
                                                {
                                                    Id = x.Key, MyProperty = string.Join(",", x.Select(v => v.MyProperty))
                                                });
            foreach (var item in orderedList)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.MyProperty);
            }
