    string entry = "Hello World !";
    StringBuilder stringToBuild = new StringBuilder(entry);
    int iForNewValue = 1;
    for (int i = 0; i < entry.Length; i++)
    {
        Console.WriteLine("ITEM [{0}] at {1}", entry[i], i);
        if (entry[i].ToString() == " ")
        {
            Console.WriteLine("=======> SPACE FOUNDED HERE");
            stringToBuild.Replace(entry[i].ToString(), iForNewValue++.ToString(), i, 1);
        }
    }
    Console.WriteLine("NEW STRING BUILD ========================> {0}", stringToBuild);
