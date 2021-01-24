        bool Keeplooping = true;
        while (Keeplooping == true)
        {
        Console.WriteLine("Select an index");
        try
        {
        int index = int.Parse(Console.ReadLine());
        Console.WriteLine(cisTuition[index].ToString());
        Keeplooping = false;
        }
        catch
        {
            Console.WriteLine("Please select a valid index");
        }
        }
