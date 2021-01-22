    MyStruct[] list = new MyStruct[5];
    
    for (int i=0;i<5;i++)
      Console.Write(list[i].Value + " ");
    Console.WriteLine();
    
    for (int i=0;i<5;i++)
      list[i].Update(i+1);
    
    for (int i=0;i<5;i++)
      Console.Write(list[i].Value + " ");
    Console.WriteLine();
