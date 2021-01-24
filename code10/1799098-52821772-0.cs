            var persons = new List<Person>{
                                           new Person{Id=1, Name="p-1", Colors="1,2"},
                                           new Person{Id=2, Name="p-2", Colors="2,1"},
                                           new Person{Id=3, Name="p-2", Colors="3,4,5"},
                                           new Person{Id=4, Name="p-2", Colors="4,5,3"}
                                        };
            persons.ForEach(x => x.ColorList = x.Colors.Split(','));
            var distinctPerson = new List<Person>();
            foreach (var item in persons)
            {
                var isExist = distinctPerson.Any(x => x.ColorList.Intersect(item.ColorList).Any());
                if(!isExist)
                {
                    distinctPerson.Add(item);
                }
            }
