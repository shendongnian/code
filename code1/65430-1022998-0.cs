    string[] oldVersion = { "test1", "test2", "test3" };
    string[] newVersion = { "test1", "test2", "test4", "test5" };
    int oldIndex = 0;
    int newIndex = 0;
    while ((oldIndex < oldVersion.Length) && (newIndex < newVersion.Length))
    {
       int comparison = oldVersion[oldIndex].CompareTo(newVersion[newIndex]);
       if (comparison < 0)
       {
          Console.WriteLine("[Removed]\t" + oldVersion[oldIndex]);
          oldIndex++;
       }
       else if (comparison == 0)
       {
          Console.WriteLine("[Same]\t\t" + oldVersion[oldIndex]);
          oldIndex++;
          newIndex++;
       }
       else
       {
          Console.WriteLine("[Added]\t\t" + newVersion[newIndex]);
          newIndex++;
       }
    }
    while (oldIndex < oldVersion.Length)
    {
       Console.WriteLine("[Removed]\t" + oldVersion[oldIndex]);
       oldIndex++;
    }
    while (newIndex < newVersion.Length)
    {
       Console.WriteLine("[Added]\t\t" + newVersion[newIndex]);
       newIndex++;
    }
