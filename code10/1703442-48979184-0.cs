            var peopleMultiGrouping = from p in people
                                      let ageSelection =
                                            p.Age < 20
                                            ? "Young" 
                                            : p.Age >= 20 && p.Age <= 40
                                                ? "Adult" 
                                                : "Senior"
                                      group p by ageSelection;
            foreach (var p in peopleMultiGrouping)
            {
                Console.WriteLine($"{p.Key}");
                foreach (var i in p)
                {
                    Console.WriteLine($" {i.Age}");
                }
            }
