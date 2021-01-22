    for (int p = 0; p < people.Count; ++p)
    {
        Console.WriteLine("List {0}:", p + 1);
        Console.WriteLine("\t{0}", String.Join(", ", people[p].Select(x => x.Name)));
    }
    Console.WriteLine("Merged:");
    foreach (var person in people.MergePreserveOrder(pp => pp.Age))
    {
        Console.WriteLine("\t{0}", person.Name);
    }
    List 1:
            8yo, 22yo, 47yo, 49yo
    List 2:
            35yo, 47yo, 60yo
    List 3:
            28yo, 55yo, 64yo
    Merged:
            8yo
            22yo
            28yo
            35yo
            47yo
            47yo
            49yo
            55yo
            60yo
            64yo
