    foreach (Animal a in listAnimals) {
        if (a is AnimalTotals) {
            Console.WriteLine($"{a.Name} {a.Gender} totals   {a.Age}");
        } else {
            Console.WriteLine($"{a.Name}   {a.Age}   {a.Gender}");
        }
    }
