    for (int i = 0; i < 5; i++)
    {
       var newI = i;
       list.Add(j => j + newI);
    }
    for (int i = 0; i < 5; i++)
    {
       Console.WriteLine(list[i](i));
    }
