            var programmers = new List<Programmer>
            {
             new Programmer("SS",12.3,2345),
             new Programmer("ADE",1.21,22345),
             new Programmer("AR",12.2,23445),
             new Programmer("NK",12.5,23455)
            };
            var progrmrs = programmers.OrderBy(t => t.DailyWage / t.Speed).ToList();
            Console.WriteLine("Name\t Speed\t DailyWage");
            foreach (var prgrm in progrmrs)
            {
                Console.WriteLine("{0}\t {1}\t {2}", prgrm.Name, prgrm.Speed, prgrm.DailyWage);
            }
