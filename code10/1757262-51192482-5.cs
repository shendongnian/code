                var dataBase = new[]{
                new MyClass(new DateTime(2018,1,1),"Jane",10),
                new MyClass(new DateTime(2017,1,1),"Jane",1),
                new MyClass(new DateTime(2016,1,1),"Jane",10),
                new MyClass(new DateTime(2018,2,1),"Jane",1),
                new MyClass(new DateTime(2018,2,2),"Jane",10),
                new MyClass(new DateTime(2017,2,2),"Jane",1),
                new MyClass(new DateTime(2016,2,2),"Jane",10),
                new MyClass(new DateTime(2018,2,8),"Jane",1),
                new MyClass(new DateTime(2017,2,8),"Jane",10),
                new MyClass(new DateTime(2016,2,8),"Jane",1),
                new MyClass(new DateTime(2018,3,1),"Jane",10),
                new MyClass(new DateTime(2017,3,1),"Jane",1),
                new MyClass(new DateTime(2016,3,1),"Jane",10),
            };
            var myCollection = new MyClasses(dataBase);
                        while (true)
            {
                Console.WriteLine("Group By What");
                var type = Console.ReadLine();
                var enumType = (MyClasses.GroupType) Enum.Parse(typeof(MyClasses.GroupType), $"GroupBy{type.UppercaseFirst()}");
                foreach (var g in myCollection.GetGroupedValue(enumType))
                {
                    Console.WriteLine(g.Key);
                }
            }
        }
