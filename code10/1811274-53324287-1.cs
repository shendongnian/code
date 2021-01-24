        bool Keeplooping = true; //Boolean to tell whether the loops continues
        while (Keeplooping == true) //while the user hasn't chosen a valid index
        {
        Console.WriteLine("Select an index");
        try //if this fails then the input is not an int or too big/small
        {
        int index = int.Parse(Console.ReadLine()); //receive input
        Console.WriteLine(cisTuition[index].ToString()); //output the value
        Keeplooping = false; //loop will end after this iteration
        }
        catch //alerts user that the input is bad and tries again
        {
            Console.WriteLine("Please select a valid index");
        }
        }
