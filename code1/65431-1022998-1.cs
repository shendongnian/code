    string[] oldVersion = { "test1", "test2", "test3" };
    string[] newVersion = { "test1", "test2", "test4", "test5" };
    int oldIndex = 0, newIndex = 0;
    while ((oldIndex < oldVersion.Length) && (newIndex < newVersion.Length)) {
       int comparison = oldVersion[oldIndex].CompareTo(newVersion[newIndex]);
       if (comparison < 0)
          Console.WriteLine("[Removed]\t" + oldVersion[oldIndex++]);
       else if (comparison > 0)
          Console.WriteLine("[Added]\t\t" + newVersion[newIndex++]);
       else {
          Console.WriteLine("[Same]\t\t" + oldVersion[oldIndex++]);
          newIndex++;
       }
    }
    while (oldIndex < oldVersion.Length)
       Console.WriteLine("[Removed]\t" + oldVersion[oldIndex++]);
    while (newIndex < newVersion.Length)
       Console.WriteLine("[Added]\t\t" + newVersion[newIndex++]);
