    string[] VariableTypes = { "Integer Type", "Real Floating Point Types" };
    string[] FloatingPointTypes = { "sbyte", "byte", "short", "ushort" };
    string[] IntergerTypes = { "sbyte", "byte", "short", "ushort" };
    
    for (int i = 0; i <= VariableTypes.Length - 1; i++)
    {
        Console.WriteLine(VariableTypes[i] + " : ");
    
        if(VariableTypes[i] == "Integer Type")
        {
            for(int j=0; j<=IntergerTypes.Length - 1; j++)
            {
                Console.Write(IntergerTypes[j] + " ");
            }
        }
        else
        {
            for(int j=0; j<=FloatingPointTypes.Length - 1; j++)
            {
                Console.Write(FloatingPointTypes[j] + " ");
            }
        }
    }
