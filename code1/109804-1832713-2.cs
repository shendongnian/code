    List<Person> persons = new List<Person>();
    for (int i = 0; i < 100000; i++)
    {
        persons.Add(new Person("P" + i.ToString(), "Janson" + i.ToString()));
    }
    Sort(persons);
    OrderBy(persons);
    const int COUNT = 30;
    Stopwatch watch = Stopwatch.StartNew();
    for (int i = 0; i < COUNT; i++)
    {
        Sort(persons);
    }
    watch.Stop();
    Console.WriteLine("Sort: {0}ms", watch.ElapsedMilliseconds);
    watch = Stopwatch.StartNew();
    for (int i = 0; i < COUNT; i++)
    {
        OrderBy(persons);
    }
    watch.Stop();
    Console.WriteLine("OrderBy: {0}ms", watch.ElapsedMilliseconds);
