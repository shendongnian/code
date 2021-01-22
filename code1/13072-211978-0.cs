            var groups = from row in testList
                      group row by row.SomeTime;
            foreach (var group in groups.OrderBy(group => group.Key))
            {
                Console.WriteLine(group.Key);
                foreach(var item in group.OrderBy(item => item.SomePrice))
                {
                    Console.WriteLine(item.SomePrice);
                }
                Console.WriteLine("Total" + group.Sum(x=>x.SomePrice));
            }
