    int[] Cola = {0,0,0};
    int Rows = Cola.Length;
    int Drinks = 17;
    
    for (int i = Drinks; i > 0; i--)
    {
       Cola[(Drinks - i) % Rows]++;
    }
    Console.WriteLine("Row 1 has " + Cola[0] + " cans.");
    Console.WriteLine("Row 2 has " + Cola[1] + " cans.");
    Console.WriteLine("Row 3 has " + Cola[2] + " cans.");
