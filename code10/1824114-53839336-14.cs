    foreach (Animal a in listAnimals) {
        if (a is AnimalTotals) {
            Console.WriteLine($"{a.Name} {a.Gender} totals: {a.Age,4}");
        } else {
            Console.WriteLine($"{a.Name,-6}   {a.Age,2}   {a.Gender}");
        }
    }
