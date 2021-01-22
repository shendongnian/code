    var baseList = new List<Base>
    {
        new Base {Name = "Base"},
        new ClassA {Name = "ClassA", Number = 1},
        new ClassB {Name = "ClassB", Description = "Desc"},
    };
    
    var test = Mapper.Map<IList<Base>, IList<DTO>>(baseList);
    Console.WriteLine(test[0].Name);
    Console.WriteLine(test[1].Name);
    Console.WriteLine((test[1]).Number);
    Console.WriteLine(test[2].Name);
    Console.WriteLine((test[2]).Description);
    Console.ReadLine();
