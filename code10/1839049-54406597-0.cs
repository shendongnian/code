    string[] VariableTypes = {
      "Integer Type", "Real Floating Point Types" 
    };
    string[][] NumberTypes = {
      new string[] { "sbyte", "byte", "short", "ushort" },
      new string[] { "float", "double" }
    };
    
    for (int i = 0; i < VariableTypes.Length; i++)
    {
        Console.Write(VariableTypes[i] + " : ");
        for(int j = 0; j < NumberTypes[i].Length; j++)
        {
            Console.Write(NumberTypes[i][j] + " ");
        }
        Console.WriteLine();
    }
