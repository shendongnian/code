    House danAndKatsHouse = new House(1000.0);
    // (after making Person.House property non-static)
    Person dan = new Person("Dan", danAndKatsHouse);
    Person kat = new Person("Kat", danAndKatsHouse);
    dan.House.SquareFootage = 1500.0;
    // outputs "1500"
    Console.WriteLine(kat.House.SquareFootage);
