    string[,] table = {
                          { "aa", "aaa" },
                          { "bb", "bbb" }
                      };
    foreach (string s in table)
    {
        Console.WriteLine(s);
    }
    /* Output is:
      aa
      aaa
      bb
      bbb
    */
