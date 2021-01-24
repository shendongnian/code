    var rl = new RefList<MyStruct>();
    ref var ms = ref rl.AddEmpty();
    ms.A = 5;
    Console.WriteLine(rl[0].A);
    ms = new MyStruct { A = 10 };
    Console.WriteLine(rl[0].A); 
