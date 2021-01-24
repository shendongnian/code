    string val;
    int Mass1, LilNum, Mass2, LilNum2, distance;
    do {
        Console.Write("Enter Mass1 ");
        val = Console.ReadLine();
    } while (!int.TryParse(val, out Mass1));
    do {
        Console.Write("Enter Lil Numbers ");
        val = Console.ReadLine();
    } while (!int.TryParse(val, out LilNum));
    do {
        Console.Write("Enter Mass2 ");
        val = Console.ReadLine();
    } while (!int.TryParse(val, out Mass2));
    do {
        Console.Write("Enter Lil Numbers ");
        val = Console.ReadLine();
    } while (!int.TryParse(val, out LilNum2));
    do {
        Console.Write("Enter Distance between Mass1 & 2 ");
        val = Console.ReadLine();
    } while (!int.TryParse(val, out distance));
